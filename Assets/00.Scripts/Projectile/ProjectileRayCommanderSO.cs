using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "SO/RaycastSO")]
public class ProjectileRayCommanderSO : ScriptableObject
{
    protected NativeList<RaycastCommand> _rays = new (Allocator.TempJob);
    protected NativeList<RaycastHit> _hits = new(Allocator.TempJob);
    protected List<ProjectileBase> _projectiles = new ();
    protected event UnityAction _OnRaycasting;

    public void AddRaycastAction(UnityAction a)
    {
        _OnRaycasting += a;
    }

    public void RemoveRaycastAction(UnityAction a)
    {
        _OnRaycasting -= a;
    }

    public void AddRaycastCommand(RaycastCommand comand, ProjectileBase projecile)
    {
        RaycastCommand ray = new RaycastCommand();
        ray = comand;
        _rays.Add(ray);
        _hits.Add(new RaycastHit());
        _projectiles.Add(projecile);
    }

    public void RunRayCasting()
    {
        _rays = new(Allocator.TempJob);
        _hits = new(Allocator.TempJob);

        _OnRaycasting?.Invoke();

        var jjob = RaycastCommand.ScheduleBatch(_rays.AsArray(), _hits.AsArray(), 0); //ToArray != AsArray. 너무나도 기괴한;;
        jjob.Complete();
        
        for (int i = 0; i < _projectiles.Count; i++)
        {
            _projectiles[i].AfterRaycast(_hits[i]);
        }

        _rays.Dispose();
        _hits.Dispose();
        _projectiles.Clear();
    }
}

using UnityEngine;

public class TestProjectile : ProjectileBase
{
    private void Awake()
    {
        _projectileRaySO.AddRaycastAction(PostRaycast);
    }

    private void OnDestroy()
    {
        _projectileRaySO.RemoveRaycastAction(PostRaycast);
    }
    private void FixedUpdate()
    {
       
    }

    protected override void PostRaycast()
    {
        _projectileRaySO.AddRaycastCommand(new RaycastCommand(transform.position, _veloctiy, new QueryParameters(_whatisTarget, false, QueryTriggerInteraction.Ignore, false), _veloctiy.magnitude * Time.fixedDeltaTime),this);

    }
}

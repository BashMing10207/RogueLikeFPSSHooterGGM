using NUnit.Framework;
using System;
using UnityEngine;

public abstract class WeaponCompo : MonoBehaviour, IGetCompoable,IAfterInitable
{
    protected Agent _agent;
    protected PlayerWeaponController _weaponController;
    protected PlayerWeaponAnim _weaponAnim;
    public int currentAmmo,remainingAmmo,maxAmmo;
    public AnimatorOverrideController animator;//총 애니메이터
    public bool isHave;                         //가지고 있는가
    protected AgentActionEventCompo _actionevCompo;
    [SerializeField]
    protected ParticleSystem[] effects = new ParticleSystem[0];
    public void Init(Agent agent)
    {
        _agent = agent;
    }
    public void AfterInit()
    {
        _weaponController = _agent.GetCompo<PlayerWeaponController>();
        _weaponAnim = _agent.GetCompo<PlayerWeaponAnim>();
        _actionevCompo = _agent.GetCompo<AgentActionEventCompo>();
    }

    public abstract void Fire(int fireType);

    public virtual void EffectInvoke(int effectType)
    {
        if(effects.Length > effectType)
            effects[effectType].Play();
    }

    public void StartReload()
    {
        if (remainingAmmo > 0 && currentAmmo < maxAmmo)
        {
            _actionevCompo.InvokeAction(AgentPlayerActions.Reload);
        }
    }

    public virtual void Reload()
    {

    }

    public virtual void ReloadFail()
    {
        
    }
}

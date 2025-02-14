using UnityEngine;

public class SingleReloadWeaponCompo : WeaponCompo,IAfterInitable,IGetCompoable
{
    public override void Fire(int fireType)
    {
        
    }

    public override void Reload()
    {
        if (remainingAmmo > 0 && currentAmmo < maxAmmo)
        {
            currentAmmo++;
        }
        else
        {
            ReloadFail();
        }
    }
}

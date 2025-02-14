using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    protected virtual HealthCompo GetHealthCompo(Transform target,ref float damageMulti)
    {
        if (target.transform.gameObject.CompareTag("Hitable") || target.transform.gameObject.CompareTag("Head"))
        {
            Transform trmTmp = target.transform.gameObject.transform;
            HealthCompo healthCompo;

            while (!trmTmp.TryGetComponent<HealthCompo>(out healthCompo))
            {
                if(trmTmp.parent == null)
                {
                    Debug.LogError("NotHitableObj. But It has HitableObj tag.");
                }

                trmTmp = trmTmp.parent;
            }
            if (target.transform.gameObject.CompareTag("Head"))
            {
                damageMulti = 2;
            }
            else
            {
                damageMulti = 1;
            }
            return healthCompo;
        }
        return null;
    }
}

using System.Collections;
using UnityEngine;

public class SyncedRaycastManager : MonoBehaviour
{
    [SerializeField]
    protected float _cycle = 0.04f;
    [SerializeField]
    protected ProjectileRayCommanderSO _commanderSO;

    private void Start()
    {
        StartCoroutine(SyncedRayCaster());
    }

    protected IEnumerator SyncedRayCaster()
    {
        while (true)
        {
            _commanderSO.RunRayCasting();
            yield return new WaitForSeconds(_cycle);
        }
    }
}

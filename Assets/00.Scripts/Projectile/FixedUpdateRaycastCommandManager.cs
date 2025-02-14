using UnityEngine;

public class FixedUpdateRaycastCommandManager : MonoBehaviour
{
    [SerializeField]
    protected ProjectileRayCommanderSO _commanderSO;
    private void FixedUpdate()
    {
        _commanderSO.RunRayCasting();
    }
}

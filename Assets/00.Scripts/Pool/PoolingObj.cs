using UnityEngine;

public class PoolingObj : MonoBehaviour,IPoolable,IGetCompoable
{
    public PoolSO poolParent;

    private Agent _agent;
    public void PoolCollect()
    {
        gameObject.SetActive(false);
        poolParent.Collect(this);
    }
    public void PoolInit(PoolSO pool)
    {
        poolParent = pool;
    }

    public void PoolGive(Vector3 pos,Quaternion rot)
    {
        gameObject.SetActive(true);
        transform.SetPositionAndRotation(pos, rot);
    }

    public void Init(Agent agent)
    {
       _agent = agent;
    }
}

using UnityEngine;

public class MoveCompo : MonoBehaviour, IGetCompoable
{
    private Agent _agent;

    public Rigidbody rigidCompo;
    public void Init(Agent agent)
    {
        _agent = agent;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IGetCompoable
{
    protected Agent _agent;
    public void Init(Agent agent)
    {
        _agent = agent;   
    }
}

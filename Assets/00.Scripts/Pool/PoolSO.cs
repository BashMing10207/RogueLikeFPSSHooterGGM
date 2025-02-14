using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "PoolSO", menuName = "SO/Pool/PoolSO")]
public class PoolSO : ScriptableObject
{
    private Stack<PoolingObj> _poolObjs = new();

    [SerializeField]
    private PoolingObj _instance;
    public void Collect(PoolingObj pool)
    {
        _poolObjs.Push(pool);
    }
    public PoolingObj Give(Vector3 position, Quaternion rotation)
    {
        if(_poolObjs.Count == 0)
        {
            Create();
        }

        PoolingObj poolObj = _poolObjs.Peek();
        poolObj.PoolGive(position, rotation);
        _poolObjs.Pop();

        return poolObj;
    }

    private void Create()
    {
        _poolObjs.Push(Instantiate(_instance));
    }
}

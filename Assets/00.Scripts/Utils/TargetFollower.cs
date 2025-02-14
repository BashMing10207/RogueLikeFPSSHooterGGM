using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] Transform _target, _source;
    void Update()
    {
        _target.SetPositionAndRotation(_source.position, _source.rotation);
    }
}

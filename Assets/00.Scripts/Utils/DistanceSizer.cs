using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSizer : MonoBehaviour
{
    [SerializeField]
    Transform _targetTrm;
    [SerializeField]
    float minDis=0.5f;

    public Vector3 originSize = Vector3.one;
    private void Awake()
    {
        originSize = transform.localScale;
        //print(Mathf)
    }
    void Update()
    {
        if(Vector3.Distance(Camera.main.transform.position, _targetTrm.position) < minDis)
        {
            
        }
    }
}

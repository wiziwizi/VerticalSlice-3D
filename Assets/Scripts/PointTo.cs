using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTo : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    void Update()
    {
        transform.LookAt(target);
    }
}

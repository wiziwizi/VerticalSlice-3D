using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRotate : MonoBehaviour
{
    /// <summary> The target objective object that we will be pointing at </summary>
    [SerializeField]
    private GameObject target;

    void Update()
    {
        // Get the distance (direction) towards the target
        Vector3 distance = target.transform.position - transform.position;
        // Calculate the angle to the target
        float angle = Mathf.Atan2(distance.x, distance.z) * Mathf.Rad2Deg;
        // Apply our world rotation to match the angle to target (i.e. face it)
        transform.eulerAngles = new Vector3(0f, angle, 0f);
    }
}

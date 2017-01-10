using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    private Vector3 objectPosition;
    private Quaternion rotation = Quaternion.identity;
    private float rotate;

    void FixedUpdate()
    {
        rotation.eulerAngles = new Vector3(transform.rotation.x, rotate, transform.rotation.z);
        transform.rotation = rotation;
    }
	
    public float GetSetRotation
    {
        get { return rotate; }
        set { rotate = value; }
    }
}

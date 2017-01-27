using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    private Vector3 _objectPosition;
    private Quaternion _rotation = Quaternion.identity;
    private float _rotateHorizontal;
    private float _rotateVertical;
	[SerializeField]
	private float _maxHeight;

    void FixedUpdate()
    {
        transform.rotation = _rotation;
        _rotation.eulerAngles = new Vector3(_rotateVertical, _rotateHorizontal, transform.rotation.z);
    }
	
    public float GetSetRotationHorizontal
    {
        get { return _rotateHorizontal; }
        set { _rotateHorizontal = value;}
    }

    public float GetSetRotationVertical
    {
        get { return _rotateVertical; }
        set
		{
			if (transform.position.y > _maxHeight)
			{_rotateVertical += 0.5f;}
			else
			{_rotateVertical = value;}
		}
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SteeringBehaviour : MonoBehaviour {

    [SerializeField]
    private GameObject _targetPoint;
	private Vector3 _target;
    [SerializeField]
    private float _mass;
    private Vector3 _position;
    private Vector3 _velocity = new Vector3(0,1,0);
    [SerializeField]
    private List <Vector3> _forces = new List <Vector3>();
    private Vector3 _allForces;
	[SerializeField]
	private float _speed;

    void Start()
    {
        _position = transform.position;
    }

    void FixedUpdate ()
    {
        Seek();
        AddForce();
        transform.position = _position;
	}

    private void Seek()
    {
        if(_targetPoint != null)
        {
            _target = _targetPoint.transform.position;
        }
        Vector3 desiredStep = _target - _position;
        desiredStep.Normalize();

        Vector3 desiredVelocity = desiredStep * _speed;

        Vector3 steeringForce = desiredVelocity - _velocity;

        _velocity += steeringForce / _mass;
    }

    private void AddForce()
    {
        for (int i = 0; i < _forces.Count; i++)
        {
            _allForces += _forces[i];
        }
        _position += (_velocity + _allForces) * Time.deltaTime;
        _allForces = new Vector3(0, 0, 0);
    }

    public Vector3 SetForce
    {
        set {_forces.Add(value);}
    }

    public Vector3 GetSetTarget
    {
        set { _target = value; }
        get { return _target; }
    }

    public float SetSpeed {
		set
		{
			_speed = value;
		}
	}
}

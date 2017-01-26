using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour {

	[SerializeField]
	private Vector3 _speed = new Vector3(10, 0, 20); //x = minimal y = current z = maximum

	void FixedUpdate () {
		transform.position += transform.forward * GetSetSpeed * Time.fixedDeltaTime;
	}

	public float GetSetSpeed
	{
		set
		{
			if (value > _speed.z)
			{_speed.y = _speed.z;}
			else if(value < _speed.x)
			{_speed.y = _speed.x;}
			else
			{_speed.y = value;}
		}
		get { return _speed.y; }
	}
}

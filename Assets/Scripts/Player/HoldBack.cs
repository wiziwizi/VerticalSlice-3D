using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBack : MonoBehaviour {

	private float distance;
	[SerializeField]
	private GameObject _other;
	[SerializeField]
	private SteeringBehaviour _speed;

	void FixedUpdate() {

		distance = Vector3.Distance(_other.transform.position, transform.position);

		if (distance > 4.5f) {_speed.SetSpeed = 21;}
		else if (distance < 4)
		{_speed.SetSpeed = 9;}
		else {_speed.SetSpeed = 10;}
	}
}

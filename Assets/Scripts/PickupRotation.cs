using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotation : MonoBehaviour {

	[SerializeField] private float _rotationSpeed;

	private Transform _thing;

	void Start(){
		_thing = GetComponent<Transform> ();
	}

	void Update (){
		_thing.transform.eulerAngles = new Vector3(
			_thing.transform.eulerAngles.x,
			_thing.transform.eulerAngles.y + _rotationSpeed * Time.fixedDeltaTime,
			_thing.transform.eulerAngles.z
		);
	}
}
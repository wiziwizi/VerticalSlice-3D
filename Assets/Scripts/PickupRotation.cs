using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotation : MonoBehaviour {

	[SerializeField]
	private float _rotationSpeed;

	private Transform thing;

	void Start(){
		thing = GetComponent<Transform> ();
	}


	void Update (){
		thing.transform.eulerAngles = new Vector3(
			thing.transform.eulerAngles.x,
			thing.transform.eulerAngles.y + _rotationSpeed * Time.fixedDeltaTime,
			thing.transform.eulerAngles.z
		);
	}
}
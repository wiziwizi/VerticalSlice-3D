using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDummy : MonoBehaviour {

	[SerializeField]
	private float healthy;

	public float GetHealth {
		get { return healthy;}
	}
}

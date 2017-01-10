using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDummy : MonoBehaviour {

	[SerializeField]
	private float healthy;

	public float GetHealth {
		get { return healthy;}
	}

	void OnGUI (){
		GUI.contentColor = Color.black;
		GUI.Label (new Rect (0, 0, 100, 100), healthy.ToString());
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

	[SerializeField]
	private int count;

	public int GetCount{get{return count;}}

	void Update(){
		if (Input.GetKeyDown (KeyCode.A)) {
			count += 1;
		}
	}
}

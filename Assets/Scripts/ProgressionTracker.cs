using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionTracker : MonoBehaviour {

	[SerializeField]
	private Sprite unTouched;

	[SerializeField]
	private Sprite thouched;

	[SerializeField]
	private Sprite filled;

	[SerializeField]
	private Image tracker;

	[SerializeField]
	private float jumpTo;

	private int counter;

	List <GameObject> checkPoints = new List<GameObject>();

	void Start(){

		tracker.sprite = unTouched;
	}

	void Update(){
		
	}
}
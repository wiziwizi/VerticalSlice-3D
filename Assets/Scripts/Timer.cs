using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	[SerializeField]
	private int _minutes;
	[SerializeField]
	private int _seconds;

	void Start (){
		StartCoroutine (Clock ());
	}

	private IEnumerator Clock () {
		if (_seconds == 0 && _minutes !=0) {
			_seconds = 60;
			_minutes -= 1;
		}
		if (_seconds > 0) {
			_seconds -= 1;
			if (!(_minutes < 10) && _seconds < 10) {
				print (_minutes + ":" + "0" + _seconds);
			}
			else if (_minutes < 10 && !(_seconds < 10)) {
				print ("0" + _minutes + ":" + _seconds);
			}
			else if (_minutes < 10 && _seconds < 10){
				print ("0" + _minutes + ":" + "0" + _seconds);
			}
			else {
				print (_minutes + ":" + _seconds);
			}
				yield return new WaitForSeconds (1);
				StartCoroutine (Clock ());
		}

	}
}
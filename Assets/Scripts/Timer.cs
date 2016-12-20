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
		if (_seconds > 0) {
			if (!(_minutes < 10) && _seconds < 10) {
				print ("Minutes: " + _minutes + " Seconds: " + "0" + _seconds);
			}
			else if (_minutes < 10 && !(_seconds < 10)) {
				print ("Minutes: " + "0" + _minutes + " Seconds: " + _seconds);
			}
			else if (_minutes < 10 && _seconds < 10){
				print ("Minutes: " + "0" + _minutes + " Seconds: " + "0" + _seconds);
			}
			else {
				print ("Minutes: " + _minutes + " Seconds: " + _seconds);
			}
				_seconds -= 1;
				yield return new WaitForSeconds (1);
				StartCoroutine (Clock ());
		}
		if (_seconds == 0 && _minutes !=0) {
			_seconds = 60;
			_minutes -= 1;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	[SerializeField]
	private int _minutes;
	[SerializeField]
	private int _seconds;
	[SerializeField]
	private string timeHolder;

	private Text clockUI;

	void Start (){
		StartCoroutine (Clock ());
		clockUI = GetComponent<Text> ();
	}

	void Update (){
		clockUI.text = timeHolder;
	}

	private IEnumerator Clock () {
		if (_seconds == 0 && _minutes !=0) {
			_seconds = 60;
			_minutes -= 1;
		}
		if (_seconds > 0) {
			_seconds -= 1;
			if (!(_minutes < 10) && _seconds < 10) {
				timeHolder = (_minutes + ":" + "0" + _seconds);
			}
			else if (_minutes < 10 && !(_seconds < 10)) {
				timeHolder = ("0" + _minutes + ":" + _seconds);
			}
			else if (_minutes < 10 && _seconds < 10){
				timeHolder = ("0" + _minutes + ":" + "0" + _seconds);
			}
			else {
				timeHolder = (_minutes + ":" + _seconds);
			}
				yield return new WaitForSeconds (1);
				StartCoroutine (Clock ());
		}

	}
}
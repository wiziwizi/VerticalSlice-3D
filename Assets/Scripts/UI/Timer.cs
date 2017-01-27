using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	[SerializeField]
	private float _minutes;
	[SerializeField]
	private float _seconds;
	[SerializeField]
	private Image timerCircle;
	private string timeHolder;
	[SerializeField]
	private float _startTimeInSeconds;
	[SerializeField]
	private float _currentTimeInSeconds;

	private Text clockUI;

	void Awake(){
		_startTimeInSeconds = _minutes * 60f + _seconds;
	}

	void Start (){
		StartCoroutine (Clock ());
		clockUI = GetComponent<Text> ();
	}

	void Update (){
		clockUI.text = timeHolder;
		_currentTimeInSeconds = _minutes * 60f + _seconds;
		timerCircle.fillAmount = 1f / 100f * (100f / _startTimeInSeconds * _currentTimeInSeconds);
		print (timerCircle.fillAmount);
	}

	private IEnumerator Clock () {
		if (_seconds == 0f && _minutes !=0f) {
			_seconds = 60f;
			_minutes -= 1f;
		}
		if (_seconds > 0f) {
			_seconds -= 1f;
			if (!(_minutes < 10f) && _seconds < 10f) {
				timeHolder = (_minutes + ":" + "0" + _seconds);
			}
			else if (_minutes < 10f && !(_seconds < 10f)) {
				timeHolder = ("0" + _minutes + ":" + _seconds);
			}
			else if (_minutes < 10f && _seconds < 10f){
				timeHolder = ("0" + _minutes + ":" + "0" + _seconds);
			}
			else {
				timeHolder = (_minutes + ":" + _seconds);
			}
				yield return new WaitForSeconds (1f);
				StartCoroutine (Clock ());
		}

	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	[SerializeField] private float _minutes;
	[SerializeField] private float _seconds;
	[SerializeField] private Image _timerCircle;

	private string _timeHolder;
	private float _startTimeInSeconds;
	private float _currentTimeInSeconds;
	private Text _clockUI;

	void Awake(){
		_startTimeInSeconds = _minutes * 60f + _seconds;
	}

	void Start (){
		StartCoroutine (Clock ());
		_clockUI = GetComponent<Text> ();
	}

	void Update (){
		_clockUI.text = _timeHolder;
		_currentTimeInSeconds = _minutes * 60f + _seconds;
		_timerCircle.fillAmount = 1f / 100f * (100f / _startTimeInSeconds * _currentTimeInSeconds);
	}

	private IEnumerator Clock () {
		if (_seconds == 0f && _minutes !=0f) {
			_seconds = 60f;
			_minutes -= 1f;
		}
		if (_seconds > 0f) {
			_seconds -= 1f;
			if (!(_minutes < 10f) && _seconds < 10f) {
				_timeHolder = (_minutes + ":" + "0" + _seconds);
			}
			else if (_minutes < 10f && !(_seconds < 10f)) {
				_timeHolder = ("0" + _minutes + ":" + _seconds);
			}
			else if (_minutes < 10f && _seconds < 10f){
				_timeHolder = ("0" + _minutes + ":" + "0" + _seconds);
			}
			else {
				_timeHolder = (_minutes + ":" + _seconds);
			}
				yield return new WaitForSeconds (1f);
				StartCoroutine (Clock ());
		}

	}
}
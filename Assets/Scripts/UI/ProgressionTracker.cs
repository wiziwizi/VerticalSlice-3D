using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionTracker : MonoBehaviour {

	[SerializeField] private Sprite _touched;
	[SerializeField] private WayPointTracker _waypoints;
	[SerializeField] private float _sizeSpeed;
	[SerializeField] private float _finalSize;
	[SerializeField] private RectTransform[] _childImage;
	[SerializeField] private Image[] _checkPoints;

	private int _currentWaypoint;
	private Vector2 _tempSize;
	private int _counter;

	void Update ()
	{
		_counter = _waypoints.GetCount;

		if (_currentWaypoint != _counter) {
			_tempSize = _childImage [_currentWaypoint].sizeDelta;
			_checkPoints [_currentWaypoint].sprite = _touched;
			if (_tempSize.x < _finalSize && _tempSize.y < _finalSize) {
				_tempSize += new Vector2 ((Time.fixedDeltaTime / _sizeSpeed), (Time.fixedDeltaTime / _sizeSpeed));
				_childImage [_currentWaypoint].sizeDelta = _tempSize;
			} else {
				_currentWaypoint = _counter;
			}
		}
	}

}
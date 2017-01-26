using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionTracker : MonoBehaviour {

	[SerializeField]
	private Sprite touched;

	[SerializeField]
	private WayPointTracker _waypoints;

	private int currentWaypoint;

	private Vector2 tempSize;

	[SerializeField]
	private float sizeSpeed;

	private int counter;

	[SerializeField]
	private float finalSize;

	[SerializeField]
	private RectTransform[] childImage;

	[SerializeField]
	private Image[] checkPoints;

	void Update ()
	{

		counter = _waypoints.GetCount;

		if (currentWaypoint != counter) {
			tempSize = childImage [currentWaypoint].sizeDelta;
			checkPoints [currentWaypoint].sprite = touched;
			if (tempSize.x < finalSize && tempSize.y < finalSize) {
				tempSize += new Vector2 ((Time.fixedDeltaTime / sizeSpeed), (Time.fixedDeltaTime / sizeSpeed));
				childImage [currentWaypoint].sizeDelta = tempSize;
			} else {
				currentWaypoint = counter;
			}
		}
	}

}
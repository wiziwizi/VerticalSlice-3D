using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPointTracker : MonoBehaviour {

    [SerializeField]
    private List<GameObject> waypoints = new List<GameObject>();
    private float distance;
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject _currentWaypoint;
    private int count;

    // Use this for initialization
    void Start () {
        _currentWaypoint.transform.position = waypoints[0].transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        distance = Vector3.Distance(_currentWaypoint.transform.position, transform.position);
        text.text = Mathf.Round(distance).ToString() + " m";

        if (distance < 5)
        {
            count++;

            if (count > waypoints.Count -1)
            {
                count = 0;
            }

            print(count);
            _currentWaypoint.transform.position = waypoints[count].transform.position;
        }
    }
}

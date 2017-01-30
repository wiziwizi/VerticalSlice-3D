using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// deze Class kan functies aanroepen in SteeringVehicle.cs
public class WaypointsFollower : MonoBehaviour {

    [SerializeField]
    private List<GameObject> waypoints = new List<GameObject>();
    [SerializeField]
    private SteeringBehaviour steeringBehaviour;
    [SerializeField]
    private bool isRepeating;
    private Vector3 waypointDistance;
    private int count;

    public void AddWayPoint(GameObject newWaypoint)
    {
        waypoints.Add(newWaypoint);
    }

    void Start ()
    {
       if(waypoints.Count > 0)
        {
            NextWaypoint();
        }
    }

    void Update()
    {
        if(Vector3.Distance(steeringBehaviour.GetSetTarget, steeringBehaviour.transform.position) < 2)
        {
            NextWaypoint();
        }
    }

    private void NextWaypoint()
    {
        if (waypoints.Count == 0)
        {
            return;
        }

        steeringBehaviour.GetSetTarget = waypoints[count].transform.position;

        if (isRepeating)
        {
            count++;
            if (count > waypoints.Count - 1)
             {
                 count = 0;
             }
        }
        else
        {
            waypoints.RemoveAt(count);
        }
    }
}

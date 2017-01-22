using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// deze Class kan functies aanroepen in SteeringVehicle.cs
public class WaypointsFollower : MonoBehaviour {

    [SerializeField]
    private List<Vector3> waypoints = new List<Vector3>();
    [SerializeField]
    private SteeringBehaviour steeringBehaviour;
    [SerializeField]
    private bool isRepeating;
    private Vector3 waypointDistance;
    private int count;

    public void AddWayPoint(Vector3 newWaypoint)
    {
        waypoints.Add(newWaypoint);
    }

    // todo: zorg ervoor dat dit component een lijst met waypoints/Vectors kan bevatten (instelbaar vanuit de editor)

    void Start ()
    {
        // todo: als er al waypoints beschikbaar zijn: ga richting de eerste waypoint
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

        // todo: checken of we al in de buurt zijn van de eerstvolgende waypoint: zo ja -> ga door naar het volgende waypoint (setTarget() op SteeringVehicle.cs)

    }
	// zorg ervoor dat er een addWayPoint method is
	

    private void NextWaypoint()
    {
        if (waypoints.Count == 0)
        {
            return;
        }

        steeringBehaviour.GetSetTarget = waypoints[count];

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

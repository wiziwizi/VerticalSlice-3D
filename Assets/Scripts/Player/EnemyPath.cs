using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour {
    [SerializeField]
	private bool _toggle;
    [SerializeField]
    private WaypointsFollower[] _wayPoints;
    [SerializeField]
    private GameObject _ship;

	void Start()
	{
			StartCoroutine(SpawnWaypoint());
	}

	IEnumerator SpawnWaypoint() 
	{
		while(_toggle)
		{
			for (int i = 0; i < _wayPoints.Length; i++)
			{
                _wayPoints[i].AddWayPoint(Instantiate(new GameObject(), _ship.transform.position, Quaternion.identity));
			}
		
		yield return new WaitForSeconds(0.5f);
		}
	}
}

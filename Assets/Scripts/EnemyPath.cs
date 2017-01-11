using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour {
	private bool toggle;
	public WaypointsFollower wp;

	void Start()
	{
			StartCoroutine(SpawnWaypoint());
	}

	IEnumerator SpawnWaypoint() 
	{
		while(true)
		{
		wp.AddWayPoint(transform.position);
		yield return new WaitForSeconds(0.1f);
		}
	}
}

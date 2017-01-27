using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour {
	private bool toggle;
	public WaypointsFollower[] wp;

	void Start()
	{
			StartCoroutine(SpawnWaypoint());
	}

	IEnumerator SpawnWaypoint() 
	{
		while(true)
		{
			for (int i = 0; i < wp.Length; i++)
			{
				wp[i].AddWayPoint(transform.position);
			}
		
		yield return new WaitForSeconds(0.5f);
		}
	}
}

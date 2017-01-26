
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float BulletSpeed;


	// Use this for initialization
	void Start () {
		
		Destroy(gameObject , 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);
		
	}
}

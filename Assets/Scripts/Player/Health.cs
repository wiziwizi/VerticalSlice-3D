using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField]
	private float _damage;
	private float _health = 100f;
	private bool _shield;

	public bool GetSetShield
	{
		get {return _shield;}
		set {_shield = value;}
	}
	public float GetHealth
	{
		get {return _health;}
	}

	void Update () {
		if (_health <= 0)
		{
			Death ();
		}
	}

	void OnColliderEnter(Collider other)
	{
		if (other.tag == "bullet")
		{
			if (_shield)
			{_shield = false;}
			else
			{_health -= _damage;}
		}
		else
		{
			Death ();
		}
	}

	void Death()
	{
		gameObject.SetActive (false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField]
	private float _damage = 15f;
	[SerializeField]
	private float _health = 100f;
	private bool _shield;

	public bool GetSetShield
	{
		get {return _shield;}
		set {_shield = value;}
	}
	public float GetSetHealth
	{
		get {return _health;}
		set {
			if (value > 90)
			{_health = 100;}
			else
			{_health = value;}
		}
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

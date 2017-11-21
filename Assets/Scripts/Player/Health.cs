using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField]
	private float _damage = 15f;
	[SerializeField]
	private float _health = 100f;
    [SerializeField]
    private GameObject RestartText;
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
		{Death ();}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "bullet")
		{
			if (_shield)
			{_shield = false;}
			else
			{_health -= _damage;}
		}
		else
		{ _health = 0;}
	}

    void Death()
	{
		gameObject.SetActive (false);
        Time.timeScale = 0;
        RestartText.SetActive(true);
	}
}

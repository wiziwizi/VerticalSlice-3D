using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDummy : MonoBehaviour {

	[SerializeField]
	private float healthy;

	[SerializeField]
	private float cooldown;

	[SerializeField]
	private float cooldownSpeed;

	private bool cooldownUsed;

	public float GetCooldown{
		get { return cooldown; }
	}

	public float GetHealth {
		get { return healthy; }
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.U)) {
			cooldownUsed = true;
			StartCoroutine (CooldownCounter ());
		}
		if(cooldown < 0){
			cooldown = 60;
			cooldownUsed = false;
		}
	}

	private IEnumerator CooldownCounter(){
		while (cooldownUsed == true && cooldown > 0){
			cooldown -= Time.deltaTime / cooldownSpeed;
			yield return null;
		}
	}
}

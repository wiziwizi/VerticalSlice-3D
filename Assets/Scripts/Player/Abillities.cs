using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abillities : MonoBehaviour {

	[SerializeField]
	private PlayerInput _playerInput;
	[SerializeField]
	private Cooldown _cooldownsShield;
	[SerializeField]
	private Cooldown _cooldownsRepair;
	[SerializeField]
	private Health _health;
	
	// Update is called once per frame
	void FixedUpdate () {
		if (_playerInput.GetAbility == 1 && !_health.GetSetShield && !_cooldownsShield.GetCooldown)
		{
			_health.GetSetShield = true;
		}

		else if (_playerInput.GetAbility == 2 && _health.GetSetHealth < 100 && !_cooldownsRepair.GetCooldown)
		{
			print (_cooldownsRepair.GetCooldown);
			_health.GetSetHealth += 10;
		}
	}
}

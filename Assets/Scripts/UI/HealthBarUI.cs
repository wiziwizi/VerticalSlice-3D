using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour {

	[SerializeField] private float _health;
	[SerializeField] private float _speed;
	[SerializeField] private Text _percentage;
	[SerializeField] private float _healthHolder;
	[SerializeField] private float _percentageSpeed;

	private Image bar;

	void Start (){
		bar = GetComponent<Image> ();
	}

	void Update (){
		if (_health / 100 > bar.fillAmount){
			bar.fillAmount += Time.deltaTime / _speed;
		}
		if (_health / 100 < bar.fillAmount){
			bar.fillAmount -= Time.deltaTime / _speed;
		}

		if (_health > _healthHolder){
			_healthHolder += Time.deltaTime / _percentageSpeed;
		}
		if (_health < _healthHolder){
			_healthHolder -= Time.deltaTime / _percentageSpeed;
		}

		_percentage.text = Mathf.RoundToInt (_healthHolder).ToString ();
	}
}

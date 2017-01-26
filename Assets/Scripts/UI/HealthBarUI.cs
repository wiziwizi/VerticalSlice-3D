using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour {

	//replace this with the real health
	[SerializeField]
	private float health;

	[SerializeField]
	private float speed;

	private Image bar;

	[SerializeField]
	private Text percentage;

	[SerializeField]
	private float healthHolder;

	[SerializeField]
	private float percentageSpeed;

	void Start (){
		bar = GetComponent<Image> ();
	}

	void Update (){
		if (health / 100 > bar.fillAmount){
			bar.fillAmount += Time.deltaTime / speed;
		}
		if (health / 100 < bar.fillAmount){
			bar.fillAmount -= Time.deltaTime / speed;
		}

		if (health > healthHolder){
			healthHolder += Time.deltaTime / percentageSpeed;
		}
		if (health < healthHolder){
			healthHolder -= Time.deltaTime / percentageSpeed;
		}

		percentage.text = Mathf.RoundToInt (healthHolder).ToString ();
	}
}

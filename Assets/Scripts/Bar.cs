using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour {

	//replace this with the real health
	[SerializeField]
	private HealthDummy health;

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
		if (health.GetHealth / 100 > bar.fillAmount){
			bar.fillAmount += speed * Time.deltaTime;
		}
		if (health.GetHealth / 100 < bar.fillAmount){
			bar.fillAmount -= speed * Time.deltaTime;
		}

		if (health.GetHealth > healthHolder){
			healthHolder += percentageSpeed * Time.deltaTime;
		}
		if (health.GetHealth < healthHolder){
			healthHolder -= percentageSpeed * Time.deltaTime;
		}

		percentage.text = Mathf.RoundToInt (healthHolder).ToString ();
	}
}

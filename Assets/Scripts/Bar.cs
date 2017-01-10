using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour {

	[SerializeField]
	private HealthDummy health;

	[SerializeField]
	private float start;

	[SerializeField]
	private float speed;

	private Image bar;

	[SerializeField]
	private Text percentage;

	void Start (){
		bar = GetComponent<Image> ();
		start = bar.fillAmount;
	}

	void Update (){
		if (health.GetHealth / 100 > start){
			bar.fillAmount += speed;
			start = bar.fillAmount;
		}
		if (health.GetHealth / 100 < start){
			bar.fillAmount -= speed;
			start = bar.fillAmount;
		}

		percentage.text = health.GetHealth.ToString();
	}
}

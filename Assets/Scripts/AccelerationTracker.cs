using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerationTracker : MonoBehaviour {

	[SerializeField]
	private Image _middleImage;
	[SerializeField]
	private Image _frontImage;
	[SerializeField]
	private Acceleration acceleration;
	
	// Update is called once per frame
	void FixedUpdate () {
		_frontImage.fillAmount = (acceleration.GetSetSpeed - 10) / 10;
		if (_frontImage.fillAmount < _middleImage.fillAmount)
		{
			_middleImage.fillAmount -= 0.004f;
		}
		else
		{
			_middleImage.fillAmount = _frontImage.fillAmount;
		}
	}
}

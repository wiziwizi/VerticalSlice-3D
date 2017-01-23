using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {
	

	[SerializeField] private Sprite unused; //This holds the image that signifies that the ability isn't used.
	[SerializeField] private Sprite used; //This holds the image that signifies that the ability is used.
	[SerializeField] private float fadeSpeed; //This determines the speed at which the image fades.
	[SerializeField] private GameObject cooldownBack; //This holds the image that is put behind the "used" image.
	[SerializeField] private Vector3 _width; // Min = x, Start = y, Max = z
	[SerializeField] private Vector3 _height; // Min = x, Start = y, Max = z
	[SerializeField] private float sizeSpeed;
	[SerializeField] private HealthDummy ship; //This gives acces to the object that holds the cooldown script.

	private Image ability; //This holds the Image component.
	private CanvasGroup faded; //This holds the CanvasGroup.
	private bool pressed; //This indicates if the button is pressed.
	private float cooldownCompare; //This holds the length of the cooldown. So it can compare itself to see if the cooldown is used.
	private RectTransform size; //This holds the RectTransform component.
	private bool pressedClone; //This indicates if the button is pressed.
	private int reached;
	private bool[] _abillities;

	void Start (){
		cooldownCompare = ship.GetCooldown;
		ability = GetComponent<Image> ();
		faded = GetComponent<CanvasGroup>();
		ability.sprite = unused;
		size = GetComponent<RectTransform> ();
		_width.y = size.sizeDelta.x;
		_height.y = size.sizeDelta.y;
		reached = 0;
	}

	void Update (){
		//Start image decrease script
		if (ability.sprite == used) {
			ability.fillAmount = 1f / 100f * (100f / cooldownCompare * ship.GetCooldown);
		}
		//End image decrease script

		//Start image reverting script
		if (ship.GetCooldown < 0.01f) {
			ability.sprite = unused;
			ability.fillAmount = 1;
		}
		//End image reverting script

		//Start behind cooldown image script
		if (ability.sprite == used) {
			cooldownBack.SetActive (true);
		} else {
			cooldownBack.SetActive (false);
		}
		//End behind cooldown image script

		//Start use script
		if (Input.GetKeyDown (KeyCode.U)) {
			pressedClone = true;
			pressed = true;
			StartCoroutine (Switcher ());
		}
		//End use script

		//Start fading script
		if (faded.alpha == 0) {
			pressed = false;
			StopCoroutine (Switcher ());
			ability.sprite = used;
			faded.alpha = 1;
		}
		//End fading script

		//Start image sizing script
		if (pressedClone == true) {
			if (reached == 0) {
				if (size.sizeDelta.x < _width.z && size.sizeDelta.y < _height.z) {
					size.sizeDelta += new Vector2 ((Time.deltaTime * sizeSpeed), (Time.deltaTime * sizeSpeed));
				} else {
					reached = 1;
				}
			}
		}

		if (pressedClone == true) {
			if (reached == 1) {
				if (size.sizeDelta.x > _width.x && size.sizeDelta.y > _height.x) {
					size.sizeDelta -= new Vector2 ((Time.deltaTime * sizeSpeed), (Time.deltaTime * sizeSpeed));
				} else {
					reached = 2;
				}
			}
		}

		if (pressedClone == true) {
			if (reached == 2) {
				if (size.sizeDelta.x < _width.y && size.sizeDelta.y < _height.y) {
					size.sizeDelta += new Vector2 ((Time.deltaTime * sizeSpeed), (Time.deltaTime * sizeSpeed));
				} else {
					reached = 0;
					pressedClone = false;
				}
			}
		}
		//End image sizing script
	}

	//Start fading coroutine
	private IEnumerator Switcher (){
		while (pressed == true && faded.alpha > 0) {
			if (pressedClone == false) {
				faded.alpha -= Time.deltaTime / fadeSpeed;
			}
			yield return null;
		}
	}
	//End fading coroutine

	public bool[] SetAbility
	{
		set
		{
			_abillities = value;
		}

	}
}
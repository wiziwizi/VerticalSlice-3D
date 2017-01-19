using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {
	
	//This holds the image that signifies that the ability isn't used.
	[SerializeField]
	private Sprite unused;

	//This holds the image that signifies that the ability is used.
	[SerializeField]
	private Sprite used;

	//This determines the speed at which the image fades.
	[SerializeField]
	private float fadeSpeed;

	//This holds the Image component.
	private Image ability;

	//This holds the CanvasGroup.
	private CanvasGroup faded;

	//This indicates if the button is pressed.
	private bool pressed;

	//This holds the image that is put behind the "used" image.
	[SerializeField]
	private GameObject cooldownBack; 

	//This gives acces to the object that holds the cooldown script.
	[SerializeField]
	private HealthDummy ship;

	//This holds the length of the cooldown. So it can compare itself to see if the cooldown is used.
	private float cooldownCompare;

	//This holds the RectTransform component.
	private RectTransform size;

	//This indicates if the button is pressed.
	private bool pressedClone;

	[SerializeField]
	private float maxWidth;

	[SerializeField]
	private float maxHeight;

	[SerializeField]
	private float minWidth;

	[SerializeField]
	private float minHeight;

	[SerializeField]
	private float sizeSpeed;

	[SerializeField]
	private float startWidth;

	[SerializeField]
	private float startHeight;

	[SerializeField]
	private int reached;

	void Start (){
		cooldownCompare = ship.GetCooldown;
		ability = GetComponent<Image> ();
		faded = GetComponent<CanvasGroup>();
		ability.sprite = unused;
		ability.fillAmount = 1;
		size = GetComponent<RectTransform> ();
		startWidth = size.sizeDelta.x;
		startHeight = size.sizeDelta.y;
		reached = 0;
	}

	void Update (){
		if (ability.sprite == used) {
			ability.fillAmount = 1f / 100f * (100f / cooldownCompare * ship.GetCooldown);
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			pressedClone = true;
		}

		if (ability.sprite == used) {
			cooldownBack.SetActive (true);
		} else {
			cooldownBack.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.U)) {
			pressed = true;
			StartCoroutine (Switcher ());
		}

		if (faded.alpha == 0) {
			pressed = false;
			StopCoroutine (Switcher ());
			ability.sprite = used;
			faded.alpha = 1;
		}
			
		if (pressedClone == true) {
			if (reached == 0) {
				if (size.sizeDelta.x < maxWidth && size.sizeDelta.y < maxHeight) {
					size.sizeDelta += new Vector2 ((Time.deltaTime * sizeSpeed), (Time.deltaTime * sizeSpeed));
				} else {
					reached = 1;
				}
			}
		}

		if (pressedClone == true) {
			if (reached == 1) {
				if (size.sizeDelta.x > minWidth && size.sizeDelta.y > minHeight) {
					size.sizeDelta -= new Vector2 ((Time.deltaTime * sizeSpeed), (Time.deltaTime * sizeSpeed));
				} else {
					reached = 2;
				}
			}
		}

		if (pressedClone == true) {
			if (reached == 2) {
				if (size.sizeDelta.x < startWidth && size.sizeDelta.y < startHeight) {
					size.sizeDelta += new Vector2 ((Time.deltaTime * sizeSpeed), (Time.deltaTime * sizeSpeed));
				} else {
					reached = 0;
					pressedClone = false;
				}
			}
		}
		/*if (reached == 1) {
				if (size.sizeDelta.x > minWidth && size.sizeDelta.y > minHeight) {
					size.sizeDelta -= new Vector2 ((Time.deltaTime * sizeSpeed), (Time.deltaTime * sizeSpeed));
				}
			}
			else if(size.sizeDelta.x < startWidth && size.sizeDelta.y < startHeight && reached == 2){
				size.sizeDelta += new Vector2 ((Time.deltaTime * sizeSpeed), (Time.deltaTime * sizeSpeed));
			}
			else {
				reached = 2;
			}*/
	}

	private IEnumerator Switcher (){
		while (pressed == true && faded.alpha > 0){
			faded.alpha -= Time.deltaTime / fadeSpeed;
			yield return null;
		}
	}

	/*private void Larger(){
		if (pressedClone == true) {
			if (size.sizeDelta.x < maxWidth && size.sizeDelta.y < maxHeight && reached == false) {
				size.sizeDelta += new Vector2 ((Time.deltaTime * sizeSpeed), (Time.deltaTime * sizeSpeed));
			} else {
				reached = true;
			}
		}
	}

	private IEnumerator Larger(){
		while (pressedClone == true) {
			if (size.sizeDelta.x < maxWidth && size.sizeDelta.y < maxHeight && reached == false) {
				size.sizeDelta += new Vector2 ((Time.deltaTime * sizeSpeed), (Time.deltaTime * sizeSpeed));
			} else {
				reached = true;
				StartCoroutine (Smaller ());
				StopCoroutine (Larger ());
			}
			yield return null;
		}
	}

	private IEnumerator Smaller(){
		while (reached == true) {
			if (size.sizeDelta.x < maxWidth && size.sizeDelta.y < maxHeight && reached == true) {
				size.sizeDelta -= new Vector2 ((Time.deltaTime * sizeSpeed), (Time.deltaTime * sizeSpeed));
			}
			yield return null;
		}
	}*/

}

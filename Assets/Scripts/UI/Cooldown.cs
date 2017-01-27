using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {
	

	[SerializeField] private Sprite _unused; //This holds the image that signifies that the ability isn't used.
	[SerializeField] private Sprite _used; //This holds the image that signifies that the ability is used.
	[SerializeField] private float _fadeSpeed; //This determines the speed at which the image fades.
	[SerializeField] private GameObject _cooldownBack; //This holds the image that is put behind the "used" image.
	[SerializeField] private Vector3 _width; // Min = x, Start = y, Max = z
	[SerializeField] private Vector3 _height; // Min = x, Start = y, Max = z
	[SerializeField] private float _sizeSpeed;
    [SerializeField] private int _abilityNumber;
    [SerializeField] private PlayerInput _abilities;
    [SerializeField] private float _cooldown;

    private Image _abilitySprite; //This holds the Image component.
	private Image _backSprite;
	private CanvasGroup _faded; //This holds the CanvasGroup.
	private bool _pressed; //This indicates if the button is pressed.
	private RectTransform _size; //This holds the RectTransform component.
	private bool _pressedClone; //This indicates if the button is pressed.
	private int _reached;
    private bool _cooldownUsed;
	private float _startCooldown;

	public bool GetCooldown
	{
		get{return _cooldownUsed;}
	}

    void Start ()
	{
		_startCooldown = _cooldown;
        _abilitySprite = GetComponent<Image> ();
		_backSprite = _cooldownBack.GetComponent<Image> ();
		_faded = GetComponent<CanvasGroup>();
        _abilitySprite.sprite = _unused;
		_size = GetComponent<RectTransform> ();
		_width.y = _size.sizeDelta.x;
		_height.y = _size.sizeDelta.y;
		_reached = 0;
	}

	void Update (){
		
		//Start image reverting script
		if (_cooldown < 0.01f) {
            _abilitySprite.sprite = _unused;
			_backSprite.fillAmount = 1;
		}
		//End image reverting script

		//Start behind cooldown image script
		if (_abilitySprite.sprite == _used) {
			_backSprite.fillAmount = 1f / 100f * (100f / _startCooldown * _cooldown);
			_abilitySprite.fillAmount = (_backSprite.fillAmount - 1) * -1;
            _cooldownBack.SetActive (true);
		} else {
			_cooldownBack.SetActive (false);
		}
		//End behind cooldown image script

		//Start use script
		if (_abilities.GetAbility == _abilityNumber)
        {
			_pressedClone = true;
			_pressed = true;
            _cooldownUsed = true;

            StartCoroutine (Switcher ());
            StartCoroutine(CooldownCounter());
        }
		//End use script

		//Start fading script
		if (_faded.alpha == 0) {
			_pressed = false;
			StopCoroutine (Switcher ());
            _abilitySprite.sprite = _used;
			_faded.alpha = 1;
		}
		//End fading script

		//Start image sizing script
		if (_pressedClone == true) {
			if (_reached == 0) {
                if (_size.sizeDelta.x < _width.z && _size.sizeDelta.y < _height.z)
                {
					_size.sizeDelta += new Vector2((Time.deltaTime * _sizeSpeed), (Time.fixedDeltaTime * _sizeSpeed));
                }
                else
                {_reached = 1;}
		    }
            if (_reached == 1)
            {
                if (_size.sizeDelta.x > _width.x && _size.sizeDelta.y > _height.x)
                {
					_size.sizeDelta -= new Vector2((Time.deltaTime * _sizeSpeed), (Time.fixedDeltaTime * _sizeSpeed));
                }
                else
                {_reached = 2;}
            }
            if (_reached == 2)
            {
                if (_size.sizeDelta.x < _width.y && _size.sizeDelta.y < _height.y)
                {
					_size.sizeDelta += new Vector2((Time.deltaTime * _sizeSpeed), (Time.fixedDeltaTime * _sizeSpeed));
                }
                else
                {
                    _reached = 0;
                    _pressedClone = false;
                }
            }
		}
        //End image sizing script

        if (_cooldown < 0)
        {
			_cooldown = _startCooldown;
            _cooldownUsed = false;
        }
    }

	//Start fading coroutine
	private IEnumerator Switcher (){
		while (_pressed == true && _faded.alpha > 0) {
			if (_pressedClone == false) {
				_faded.alpha -= Time.deltaTime / _fadeSpeed;
			}
			yield return null;
		}
	}
	//End fading coroutine

    private IEnumerator CooldownCounter(){
		while (_cooldownUsed == true && _cooldown > 0){
			_cooldown -= Time.fixedDeltaTime;
			yield return null;
		}
	}
}
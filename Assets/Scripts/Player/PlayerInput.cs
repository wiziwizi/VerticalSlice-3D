using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    private float _moveHorizontal;
    private float _moveVertical;
    private float _acceleration;
	private int _abillity;

    [SerializeField]
	private Acceleration speed;
    [SerializeField]
    private PlayerRotation playerRotation;
	[SerializeField]
	private Cooldown cooldown;

    private void FixedUpdate()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        _moveVertical = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftControl))
        {
            _acceleration = -1;
        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            _acceleration = 1;
        }
        else
        {
            _acceleration = 0;
        }

		if (Input.GetKeyDown (KeyCode.Alpha1))
		{_abillity = 1;}

		else if (Input.GetKeyDown (KeyCode.Alpha2))
		{_abillity = 2;}

        else if(Input.GetKeyDown (KeyCode.Alpha3))
		{_abillity = 3;}
        else
        {_abillity = 0;}

		speed.GetSetSpeed += _acceleration / 6;
        playerRotation.GetSetRotationHorizontal += _moveHorizontal;
		playerRotation.GetSetRotationVertical += _moveVertical * -1;
    }

    public int GetAbility
    {
        get { return _abillity; }
    }
}

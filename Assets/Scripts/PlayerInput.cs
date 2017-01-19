using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    private float _moveHorizontal;
    private float _moveVertical;
    private float _acceleration;

    [SerializeField]
	private Acceleration speed;
    [SerializeField]
    private PlayerRotation playerRotation;

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

		speed.GetSetSpeed += _acceleration / 4;
        playerRotation.GetSetRotationHorizontal += _moveHorizontal;
        playerRotation.GetSetRotationVertical += _moveVertical *-1;
    }
}

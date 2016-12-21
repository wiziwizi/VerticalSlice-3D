using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    private float _moveHorizontal;
    private float _moveVertical;
    [SerializeField]
    private SteeringBehaviour steeringBehaviour;

    private void FixedUpdate()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        _moveVertical = Input.GetAxis("Vertical");

        steeringBehaviour.GetSetSpeed += _moveVertical / 4;
    }
}

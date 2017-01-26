using UnityEngine;

public class Machinegun : MonoBehaviour
{
    private bool _isFiring;
    [SerializeField]
    private Bullet _bullet;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private float _fireRate;

    private float _shotCounter;
    [SerializeField]
    private Transform _shotPoint;

    private void Update ()
    {
        _isFiring = Input.GetMouseButton(0);


        if (_isFiring)
        {
            _shotCounter -= Time.deltaTime;
            if (!(_shotCounter <= 0)) return;
            _shotCounter = _fireRate;
            var newBullet = Instantiate(_bullet, _shotPoint.position, _shotPoint.rotation);
            newBullet.BulletSpeed = _bulletSpeed;
        }
        else
        {
            _shotCounter = 0;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform _cannon1;
    [SerializeField] private Transform _cannon2;

    [SerializeField] private GameObject _bullet;

    private Transform _nextCannonToShoot;

    private float _cannonMaxCd = 1.5f;
    private float _shotMaxCd = 0.25f;

    private bool _canShoot;
    private bool _isShooting;

    private float _cooldownTimer = 0;

    void Awake()
    {
        if (_cannon1)
        {
            _nextCannonToShoot = _cannon1;
        }

        _canShoot = true;

        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("TurretProjectile"), LayerMask.NameToLayer("Shield"), true);
    }

    void Update()
    {
        if (!_canShoot && !_isShooting)
        {
            if (_cooldownTimer < _cannonMaxCd)
            {
                _cooldownTimer += Time.deltaTime;
            }
            else
            {
                _canShoot = true;
                _cooldownTimer = 0;
            }
        }

        if (_isShooting)
        {
            if (_cooldownTimer < _shotMaxCd)
            {
                _cooldownTimer += Time.deltaTime;
            }
            else
            {
                _canShoot = true;
                _cooldownTimer = 0;
            }
        }
    }

    public void Shoot()
    {
        if (_canShoot && _nextCannonToShoot)
        {
            Instantiate(_bullet, _nextCannonToShoot.position, _nextCannonToShoot.rotation);

            _canShoot = false;
            if (_nextCannonToShoot == _cannon1)
            {
                _nextCannonToShoot = _cannon2;
            }
            else
            {
                _nextCannonToShoot = _cannon1;
            }

            _isShooting = !_isShooting;

        }
    }

    public void Reset()
    {
        _isShooting = false;
        _canShoot = false;
        _cooldownTimer = 0;
    }
}

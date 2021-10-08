using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGun : Gun
{
    private const int MAX_AMMO_IN_MAGAZINE = 25;
    private const int MAX_AMMO = 100;

    [SerializeField] private float _range;
    [SerializeField] private float _damage;
    [SerializeField] private GameObject _bulletHoleObject;
    [SerializeField] private Camera _mainCam;
    [SerializeField] private AudioSource _reloadSound;

    private float _reloadDelay = 2f;

    private bool _isReloading = false;

    private int _ammoInReserve = 0;
    public int AmmoInReserve
    {
        get { return _ammoInReserve; }
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetButtonDown("Reload"))
        {
            InvokeReload();
        }
    }

    protected override void Shoot()
    {
        if (_isReloading)
        {
            return;
        }
        if (_ammo == 0)
        {
            if (_ammoInReserve == 0)
            {
                return;
            }
            else if (_ammoInReserve > 0)
            {
                InvokeReload();
                return;
            }
        }

        RaycastHit info;
        var start = _mainCam.transform.position;
        var end = _mainCam.transform.position + _mainCam.transform.forward * _range;

        if (Physics.Raycast(_mainCam.transform.position, _mainCam.transform.forward, out info, _range,
            Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore))
        {
            if (info.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                info.transform.gameObject.GetComponent<EnemyHealth>().TakeDamage(_damage);
            }
            else if (info.transform.gameObject.layer == LayerMask.NameToLayer("Shield"))
            {
                info.transform.gameObject.GetComponent<SubShieldHealth>().TakeDamage(_damage);
            }
            else if (_bulletHoleObject && info.transform.gameObject.layer == LayerMask.NameToLayer("Static"))
            {
                GameObject holeObject = Instantiate(_bulletHoleObject, info.transform);
                Quaternion rot = Quaternion.FromToRotation(holeObject.transform.forward, info.normal);
                holeObject.transform.rotation =  rot;
                holeObject.transform.position = info.point + info.normal * 0.01f;
                holeObject.transform.localScale = new Vector3(1 / info.transform.lossyScale.x,
                    1 / info.transform.lossyScale.y,
                    1 / info.transform.lossyScale.z);
            }

        }

        if (_muzzleFlash)
        {
            _muzzleFlash.Play();

        }
        _sound.Play();
        _ammo--;
    }

    void InvokeReload()
    {
        if (!_isReloading && _ammoInReserve > 0 && _ammo < MAX_AMMO_IN_MAGAZINE)
        {
            _isReloading = true;
            _reloadSound.Play();
            Invoke("Reload", _reloadDelay);
        }
    }

    void Reload()
    {
        if (_ammoInReserve == 0)
        {
            return;
        }

        if (_ammo == 0 && _ammoInReserve >= MAX_AMMO_IN_MAGAZINE)
        {
            _ammo = MAX_AMMO_IN_MAGAZINE;
            _ammoInReserve -= MAX_AMMO_IN_MAGAZINE;
        }
        else
        {
            int ammoNeeded = MAX_AMMO_IN_MAGAZINE - _ammo;
            if (_ammoInReserve >= ammoNeeded)
            {
                _ammo += ammoNeeded;
                _ammoInReserve -= ammoNeeded;
            }
            else
            {
                _ammo += _ammoInReserve;
                _ammoInReserve = 0;
            }
        }

        _isReloading = false;
    }

    public void AddAmmo(int amount)
    {
        _ammoInReserve += amount;
        if (_ammoInReserve > MAX_AMMO)
        {
            _ammoInReserve = MAX_AMMO;
        }
    }
}

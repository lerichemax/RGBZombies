using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject _activeGun;

    public GameObject ActiveGun
    {
        get { return _activeGun; }
    }

    [SerializeField] private GameObject _inactiveGun;
    [SerializeField] private GameObject _activeAmmoUi;
    [SerializeField] private GameObject _inactiveAmmoUi;

    void Awake()
    {
        if (_activeGun)
        {
            _activeGun.SetActive(true);
        }

        if (_inactiveGun)
        { 
            _inactiveGun.SetActive(true); //setting to true to call awake
            _inactiveGun.SetActive(false);   
        }

        if (_activeAmmoUi)
        {
            _activeAmmoUi.SetActive(true);
        }

        if (_inactiveAmmoUi)
        {
            _inactiveAmmoUi.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetAxis("SwitchWeapon") != 0 && _activeGun != null && _inactiveGun != null)
        {
            //switch Gun
            GameObject tempGun = _activeGun;
            _activeGun.SetActive(false);
            _activeGun = _inactiveGun;
            _activeGun.SetActive(true);
            _inactiveGun = tempGun;

            //switch ammo ui
            GameObject tempUi = _activeAmmoUi;
            _activeAmmoUi.SetActive(false);
            _activeAmmoUi = _inactiveAmmoUi;
            _activeAmmoUi.SetActive(true);
            _inactiveAmmoUi = tempUi;
        }
    }
}

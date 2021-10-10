using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyGun : Gun
{
    [SerializeField] private GameObject[] _bullet;
    [SerializeField] private GameObject _heavyAmmoUI;
    [SerializeField] private int _initialAmmo = 0;
    private float _timeBetweenShots = 0.75f;
    private float _shotTimer;

    private bool _canShoot = true;

    private int _currentBulletIndex = 0;

    private int _nbrInstantiatedBullets = 3;
    private GameObject[,] _instantiatedBullets;
    private int[] _instantiatedBulletIndex;

    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < _bullet.Length; i++)
        {
            _bullet[i].gameObject.SetActive(true);
            _bullet[i].GetComponent<HeavyAmmo>().Ammo = _initialAmmo;
        }

        _instantiatedBullets = new GameObject[_bullet.Length, _nbrInstantiatedBullets];
        for (int i = 0; i < _bullet.Length; i++)
        {
            for (int j = 0; j < _nbrInstantiatedBullets; j++)
            {
                _instantiatedBullets[i, j] = Instantiate(_bullet[i], transform.position, transform.rotation);
                _instantiatedBullets[i,j].SetActive(false);
            }
        }

        _instantiatedBulletIndex = new int[_bullet.Length];

    }

    protected override void Update()
    {
        base.Update();

        if (!gameObject.activeInHierarchy)
        {
            return;
        }
        if (Input.GetButtonDown("SwitchAmmo"))
        {
            int prevIdx = _currentBulletIndex++;
            if (_currentBulletIndex >= _bullet.Length)
            {
                _currentBulletIndex = 0;
            }

            string str = "HeavyAmmo_" + _bullet[_currentBulletIndex].tag;
            _heavyAmmoUI.transform.Find("HeavyAmmo_" + _bullet[_currentBulletIndex].tag).gameObject.SetActive(true);
            _heavyAmmoUI.transform.Find("HeavyAmmo_" + _bullet[prevIdx].tag).gameObject.SetActive(false);
        }

        if (!_canShoot)
        {
            _shotTimer += Time.deltaTime;
            if (_shotTimer >= _timeBetweenShots)
            {
                _canShoot = true;
            }
        }

        _ammo = _bullet[_currentBulletIndex].GetComponent<HeavyAmmo>().Ammo;
    }

    protected override void Shoot()
    {
        if (_canShoot && _ammo > 0)
        {
            _shotTimer = 0;
            //GameObject bulletObject = (GameObject)Instantiate(_bullet[_currentBulletIndex], _muzzle.transform.position, _muzzle.transform.rotation);
            GameObject bulletObject = _instantiatedBullets[_currentBulletIndex, _instantiatedBulletIndex[_currentBulletIndex]];
            bulletObject.transform.position = _muzzle.transform.position;
            bulletObject.transform.rotation = _muzzle.transform.rotation;
            bulletObject.SetActive(true);
            
            _instantiatedBulletIndex[_currentBulletIndex]++;
            if (_instantiatedBulletIndex[_currentBulletIndex] >= _nbrInstantiatedBullets)
            {
                _instantiatedBulletIndex[_currentBulletIndex] = 0;
            }

            _canShoot = false;
            _sound.Play();
            _bullet[_currentBulletIndex].GetComponent<HeavyAmmo>().Ammo--;
        }
    }

    public void AddAmmo(string tag, int amount)
    {
        for (int i = 0; i < _bullet.Length; i++)
        {
            if (_bullet[i].tag == tag)
            {
                _bullet[i].GetComponent<HeavyAmmo>().Ammo += amount;
                break;
            }
        }
    }
}
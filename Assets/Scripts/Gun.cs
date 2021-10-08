using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{

    [SerializeField] protected Transform _muzzle;
    [SerializeField] protected ParticleSystem _muzzleFlash;

    [SerializeField] protected int _ammo;

    private GameManager _manager;
    public int Ammo
    {
        get { return _ammo; }
    }


    [SerializeField] protected AudioSource _sound;

    protected virtual void Awake()
    {
        _manager = FindObjectOfType<GameManager>();
    }

    protected virtual void Update()
    {
        if (Input.GetButtonDown("Fire1") && _muzzle && !_manager.IsPaused)
        {
            Shoot();
        }
    }

    protected abstract void Shoot();
}

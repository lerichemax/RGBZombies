using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : EnemyHealth
{
    [SerializeField] private GameObject _effect;
    [SerializeField] private EnemyManager _manager;


    protected override void Die()
    {
        Instantiate(_effect, transform.position, transform.rotation);
        if (_manager)
        {
            _manager.TurretDestroyed();
        }
        
        base.Die();
    }

    

}

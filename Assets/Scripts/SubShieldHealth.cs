using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubShieldHealth : MonoBehaviour
{
    [SerializeField] private ShieldHealth _shieldHealth;


    public void TakeDamage(float amount)
    {
        if (_shieldHealth)
        {
            _shieldHealth.TakeDamage(amount);
        }
    }
}

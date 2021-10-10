using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Cryptography;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float _maxHealth;
    
    protected float _health;

    public float HealthPercentage
    {
        get { return _health / _maxHealth; }
    }

    protected virtual void Awake()
    {
        _health = _maxHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        _health -= amount;

        if (_health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }
}

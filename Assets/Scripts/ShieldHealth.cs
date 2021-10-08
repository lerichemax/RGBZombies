using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : EnemyHealth
{
    [SerializeField] private float _armor = 10;

    public override void TakeDamage(float amount)
    {
        float actualAmount = amount - _armor;
        base.TakeDamage(actualAmount >= 0 ? actualAmount : 0);
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}

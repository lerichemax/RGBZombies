using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAmmoPickupFixedAmount : HeavyAmmoPickUp
{
    [SerializeField] private int _fixedAmount;

    void Start()
    {
        _amount = _fixedAmount;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAmmo : MonoBehaviour
{
    private int _ammo;

    public int Ammo
    {
        get { return _ammo; }
        set { _ammo = value; }
    }

}

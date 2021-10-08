using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAmmoPickUp : AmmoPickUp
{

    protected override void PickUp(GameObject picker)
    {
        Transform heavy = picker.transform.Find("Hand").transform.Find("Heavy");

        heavy.GetComponent<HeavyGun>().AddAmmo(gameObject.tag, _amount);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeavyAmmoText : MonoBehaviour
{
    [SerializeField] private HeavyGun _gun;
    [SerializeField] private Text _text;

    void Update()
    {
        if (_gun && _text)
        {
            _text.text = _gun.Ammo.ToString();
        }
    }
}

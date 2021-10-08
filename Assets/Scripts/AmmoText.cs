using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoText : MonoBehaviour
{
    [SerializeField] private Text _magazineText;
    [SerializeField] private Text _reserveText;
    [SerializeField] private LightGun _gun;


    // Update is called once per frame
    void Update()
    {
        if (_gun && _magazineText && _reserveText)
        {
            _magazineText.text = _gun.Ammo.ToString();
            _reserveText.text = _gun.AmmoInReserve.ToString();
        }
    }
}

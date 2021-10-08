using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoTextTMP : MonoBehaviour
{
    private TextMeshPro _text;

    [SerializeField] private AmmoPickUp _pickUp;

    void Awake()
    {
        _text = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        if (_text && _pickUp)
        {
            _text.text = _pickUp.Amount.ToString();
        }
    }
}

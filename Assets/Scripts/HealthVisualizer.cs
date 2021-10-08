using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthVisualizer : MonoBehaviour
{

    [SerializeField] private Health _health;

    private Image _image;

    void Awake()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        var scale = _image.transform.localScale;
        _image.transform.localScale = new Vector3(_health.HealthPercentage, scale.y, scale.z);
    }
}

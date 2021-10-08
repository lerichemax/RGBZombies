using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnim : MonoBehaviour
{
    enum RotationAngle
    {
        x,y,z
    }

    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _scaleSpeed;

    [SerializeField] private bool _isShrinking;
    [SerializeField] private RotationAngle _rotationAngle;
    [SerializeField] private float _rotationSpeed;
    void Update()
    {
        if (transform.localScale.x >= _maxScale && !_isShrinking)
        {
            _isShrinking = true;
        }
        else if (transform.localScale.x <= _minScale && _isShrinking)
        {
            _isShrinking = false;
        }

        var currScale = transform.localScale;

        if (_isShrinking)
        {
            transform.localScale = currScale - Vector3.one * (_scaleSpeed * Time.deltaTime);
        }
        else
        {
            transform.localScale = currScale + Vector3.one * (_scaleSpeed * Time.deltaTime);
        }

        switch (_rotationAngle)
        {
            case RotationAngle.x:
                transform.Rotate(transform.right, _rotationSpeed * Time.deltaTime);
                break;
            case RotationAngle.y:
                transform.Rotate(transform.up, _rotationSpeed * Time.deltaTime);
                break;
            case RotationAngle.z:
                transform.Rotate(transform.forward, _rotationSpeed * Time.deltaTime);
                break;
        }
    }
}

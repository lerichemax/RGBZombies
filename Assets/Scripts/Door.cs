using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _door;

    private float _speed = 50f;
    private bool _isOpening = false;
    private bool _isClosing = false;

    private Vector3 _initialPosition;

    void Awake()
    {
        _initialPosition = _door.transform.position;
    }

    void Update()
    {
        if (_isOpening && _target)
        {
            Vector3 displacement = Vector3.zero;
            displacement.y += _speed * Time.deltaTime;
            _door.transform.position += displacement;
            if (_door.transform.position.y > _target.transform.position.y)
            {
                _isOpening = false;
            }
        }
        else if (_isClosing)
        {
            Vector3 displacement = Vector3.zero;
            displacement.y += _speed * Time.deltaTime;
            _door.transform.position -= displacement;
            if (_door.transform.position.y < _initialPosition.y)
            {
                _isClosing = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Open(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Close();
        }
    }

    protected virtual void Open(GameObject obj = null)
    {
        _isOpening = true;
    }

    protected virtual void Close(GameObject obj = null)
    {
        _isClosing = true;
        _isOpening = false;
    }
}

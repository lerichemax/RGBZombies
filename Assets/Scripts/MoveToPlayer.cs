using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{

    private float _moveSpeed = 25f;
    private Transform _target;

    void Update()
    {
        if (_target)
        {
            Vector3 direction = _target.position - transform.position;
            direction.Normalize();

            transform.parent.position += direction * _moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _target = other.transform;
        }
    }
}

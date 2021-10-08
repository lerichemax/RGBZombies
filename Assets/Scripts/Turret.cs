using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject _head;
    [SerializeField] private float _rotationSpeed = 50;
    [SerializeField] private Transform _rayOrigin;
    [SerializeField] private Cannon _cannon;
    private GameObject _target;

    void Update()
    {
        if (!_target)
        {
            return;
        }

        Vector3 fwd = _target.transform.position - transform.position;
        fwd.Normalize();
        Quaternion rot = Quaternion.LookRotation(fwd, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * _rotationSpeed);
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        Vector3 targetPos = _target.transform.position - new Vector3(0,1,0);
        fwd = targetPos - _head.transform.position;
        fwd.Normalize();
        rot = quaternion.LookRotation(fwd, transform.up);
        _head.transform.rotation = Quaternion.Slerp(_head.transform.rotation, rot, _rotationSpeed * Time.deltaTime);
        _head.transform.rotation = Quaternion.Euler(_head.transform.eulerAngles.x, transform.eulerAngles.y, 0);

        Ray ray = new Ray(_rayOrigin.position, _rayOrigin.forward);

        RaycastHit hitInfo;
        if (Physics.SphereCast(ray, 5, out hitInfo))
        {
            Debug.Log(hitInfo.transform.name);
            if (hitInfo.transform.tag == "Player")
            {
                _cannon.Shoot();
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _target = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _target = null;
            _cannon.Reset();
        }
    }


}

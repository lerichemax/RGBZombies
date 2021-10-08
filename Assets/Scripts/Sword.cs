using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sword : MonoBehaviour
{
    private BoxCollider _collider;

    [SerializeField] private float _damage;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
    }

    public void SetColliderActive(bool isActive)
    {
        _collider.enabled = isActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Health health = other.gameObject.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(_damage);
            }
        }
    }
}

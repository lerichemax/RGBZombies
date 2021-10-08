using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private int _amount;

    private float _yAboveSpawn = 1.5f;

    void Awake()
    {
        Vector3 pos = transform.position;
        pos.y += _yAboveSpawn;
        transform.position = pos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health)
            {
                health.GainHealth(_amount);
            }
            Destroy(gameObject);
        }
    }
}

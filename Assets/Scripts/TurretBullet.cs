using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    private AudioSource _explosionSound;

    private float _speed = 1000;
    private float _damage = 40;
    private float _range = 7.5f;


    void Awake()
    {

        _explosionSound = GetComponent<AudioSource>();
        GetComponent<Rigidbody>().AddForce(transform.forward * _speed);
    }

    void OnCollisionEnter()
    {
        Instantiate(_explosion, transform.position, transform.rotation);
        _explosionSound.Play();
        Collider[] colls = Physics.OverlapSphere(transform.position, _range);
        for (int i = 0; i < colls.Length; i++)
        {
            if (colls[i].gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                GameObject playerObj = colls[i].gameObject;
                float dist = (transform.position - playerObj.transform.position).magnitude;
                float distPercent = (_range - dist) / _range;

                Health health = playerObj.GetComponentInChildren<Health>();
                if (health)
                {
                    health.TakeDamage(distPercent * _damage);
                }

                break;
            }
        }

        Destroy(gameObject);
    }
}

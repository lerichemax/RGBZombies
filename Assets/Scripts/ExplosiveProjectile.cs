using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : MonoBehaviour
{
    [SerializeField] private GameObject _explosionObject;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionDamage;


    private float _range = 10f;
    private float _initialForce = 1800f;

    void Awake()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * _initialForce);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shield") && other.gameObject.CompareTag(gameObject.tag))
        {
            SubShieldHealth h = other.gameObject.GetComponent<SubShieldHealth>();
            if (h)
            {
                h.TakeDamage(_explosionDamage);
            }
        }

        if (other.gameObject.CompareTag(gameObject.tag) && other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            ApplyExplosionDamage(other.gameObject);
        }
        Explode();
        Destroy(gameObject);
    }

    void Explode()
    {
        Instantiate(_explosionObject, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, _range, Physics.AllLayers, QueryTriggerInteraction.Ignore);

        foreach (Collider col in colliders)
        {
            if (col.gameObject.CompareTag(gameObject.tag))
            {
                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.AddExplosionForce(_explosionForce, transform.position, _range);
                }
                if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    ApplyExplosionDamage(col.gameObject);
                }
            }
        }
    }

    private void ApplyExplosionDamage(GameObject enemyObj)
    {
        float dist = (transform.position - enemyObj.transform.position).magnitude;
        float distPercent = (_range - dist) / _range;

        EnemyHealth health = enemyObj.GetComponent<EnemyHealth>();
        if (health)
        {
            health.TakeDamage(distPercent * _explosionDamage);
        }

        NavMeshAgentBehaviour agent = enemyObj.GetComponent<NavMeshAgentBehaviour>();
        if (agent)
        {
            agent.CancelForceAfterTime(0.15f);
        }
    }

}

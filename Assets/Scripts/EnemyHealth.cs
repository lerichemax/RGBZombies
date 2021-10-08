using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject _healthVisualizer;

    private EnemyManager _enemyManager;

    public EnemyManager EnemyManager
    {
        set { _enemyManager = value; }
    }

    
    private ParticleSystem _particles;

    private bool _isHit = false;

    protected override void Awake()
    {
        _particles = GetComponent<ParticleSystem>();
        _healthVisualizer.SetActive(false);
        base.Awake();
    }

    public override void TakeDamage(float amount)
    {
        if (!_isHit)
        {
            _isHit = true;
            if (_healthVisualizer != null)
            {
                _healthVisualizer.SetActive(true);
            }
        }

        base.TakeDamage(amount);

        if (_particles)
        {
            _particles.Play();
        }
    }

    protected override void Die()
    {
        ItemSpawner[] spawners = GetComponents<ItemSpawner>();

        if (spawners.Length > 0)
        {
            foreach (ItemSpawner spawner in spawners)
            {
                spawner.Spawn();
            }
        }


        if (_enemyManager)
        {
            _enemyManager.RemoveEnemy(gameObject);
        }

        base.Die();
    }
}

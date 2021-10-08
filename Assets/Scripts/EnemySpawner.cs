using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval;

    [SerializeField] private GameObject _enemyToSpawn;
    [SerializeField] private Transform _spawnPos;

    [SerializeField] private Transform _enemyTarget;

    [SerializeField] private EnemyManager _manager;

    private bool _canSpawn;

    public bool CanSpawn
    {
        set { _canSpawn = value; }
    }

    private float _spawnTimer;

    void Start()
    {
        _canSpawn = true;
        _spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canSpawn)
        {
            if (_spawnTimer >= _spawnInterval)
            {
                _spawnTimer = 0;
                GameObject enemyObject = Instantiate(_enemyToSpawn, _spawnPos.position, _spawnPos.rotation);
                enemyObject.GetComponent<NavMeshAgentBehaviour>().Target = _enemyTarget;
                enemyObject.GetComponent<EnemyHealth>().EnemyManager = _manager;
                _manager.SpawnEnemy(enemyObject);
            }
            else
            {
                _spawnTimer += Time.deltaTime;
            }
        }
    }
}

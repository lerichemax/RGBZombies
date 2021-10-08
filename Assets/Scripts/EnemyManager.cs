using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int _maxNbrEnemies;
    [SerializeField] private List<EnemySpawner> _spawners;
    [SerializeField] private GameOverMenu _gameOver;

    private List<GameObject> _enemies = new List<GameObject>();

    private int _nbrEnemies;


    void Awake()
    {
        _nbrEnemies = 0;
    }

    public void SpawnEnemy(GameObject enemy)
    {
        _enemies.Add(enemy);

        if (++_nbrEnemies >= _maxNbrEnemies)
        {
            SetSpawnersCanSpawn(false);
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (_enemies.Contains(enemy))
        {
            _enemies.Remove(enemy);
            if (_nbrEnemies-- == _maxNbrEnemies)
            {
                SetSpawnersCanSpawn(true);
            }
        }
    }

    private void SetSpawnersCanSpawn(bool canSpawn)
    {
        foreach (EnemySpawner spawner in _spawners)
        {
            spawner.CanSpawn = canSpawn;
        }
    }

    public void TurretDestroyed()
    {
        foreach (EnemySpawner spawner in _spawners)
        {
            spawner.gameObject.SetActive(false);
        }

        foreach (GameObject enemy in _enemies)
        {
            enemy.SetActive(false);
        }

        _gameOver.GameOver("Thanks for playing !");
    }
}

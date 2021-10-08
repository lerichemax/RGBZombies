using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _itemToSpawn;

    [SerializeField] private float _probability = 0.5f;

    void Awake()
    {
        Mathf.Clamp(_probability, 0f, 1f);
    }

    public GameObject Spawn()
    {
        if (CanSpawn())
        {
            int index = Random.Range(0, _itemToSpawn.Length);
            GameObject item = Instantiate(_itemToSpawn[index], transform.position, transform.rotation);
            return item;
        }

        return null;
    }

    public GameObject Spawn(Transform trans)
    {
        if (CanSpawn())
        {
            int index = Random.Range(0, _itemToSpawn.Length);
            GameObject item = Instantiate(_itemToSpawn[index], trans.position, trans.rotation);
            return item;
        }

        return null;
    }

    private bool CanSpawn()
    {
        int rand = Random.Range(0, 100);

        return rand <= _probability * 100;
    }
}

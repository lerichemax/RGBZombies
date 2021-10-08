using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObject : MonoBehaviour
{
    [SerializeField] private GameObject _toActivate;

    void Awake()
    {
        if (_toActivate)
        {
            _toActivate.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _toActivate.SetActive(true);
            Destroy(gameObject);
        }
    }
}

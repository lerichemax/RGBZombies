using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    [SerializeField] private GameObject _toDeactivate;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _toDeactivate.SetActive(false);
            Destroy(gameObject);
        }
    }
}
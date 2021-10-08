using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] private int _maxAmount = 25;

    protected int _amount;

    public int Amount
    {
        get { return _amount; }
    }

    void Awake()
    {
        _amount = Random.Range(1, _maxAmount);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PickUp(other.gameObject);
        }
    }

    protected virtual void PickUp(GameObject picker)
    {
        Transform rifle = picker.transform.Find("Hand").transform.Find("Rifle");

        rifle.GetComponent<LightGun>().AddAmmo(_amount);
        Destroy(gameObject);
    }

}

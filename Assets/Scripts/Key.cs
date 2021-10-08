using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject _uiImageToDisplay;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DoorOpener opener = other.gameObject.GetComponent<DoorOpener>();
            if (opener)
            {
                opener.AddKey(this);

                if (_uiImageToDisplay)
                {
                    _uiImageToDisplay.SetActive(true);
                }
                
                gameObject.SetActive(false);
            }
        }
    }
}

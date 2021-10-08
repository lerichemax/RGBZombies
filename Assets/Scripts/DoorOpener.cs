using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorOpener : MonoBehaviour
{
    private List<Key> _keys = new List<Key>();

    public void AddKey(Key key)
    {
        foreach (Key ownedKey in _keys)
        {
            if (key == ownedKey)
            {
                return;
            }
        }

        _keys.Add(key);
    }

    public bool HasKey(LockedDoor door)
    {
        if (_keys.Count == 0)
        {
            return false;
        }
        
        foreach (Key key in _keys)
        {
            if (key == door.AssociatedKey)
            {
                return true;
            }
        }

        return false;
    }
}

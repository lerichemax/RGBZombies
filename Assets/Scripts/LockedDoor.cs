using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Door
{
    [SerializeField] private Key _associatedKey;
    public Key AssociatedKey
    {
        get { return _associatedKey; }
    }

    protected override void Open(GameObject obj)
    {
        DoorOpener opener = obj.GetComponent<DoorOpener>();
        if (opener && opener.HasKey(this))
        {
            base.Open();
        }
    }
}

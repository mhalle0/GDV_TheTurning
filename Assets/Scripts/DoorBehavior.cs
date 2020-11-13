using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public float teleportX = 0;
    public float teleportY = 0;
    public bool isLocked = false;
    public Sprite unlockedDoor; //Only needs to be assigned if door is locked
    public bool isUnlockTrigger = false;
    public List<DoorBehavior> doorsToUnlock = new List<DoorBehavior>(); //Only need if this is an unlock trigger

    public Vector3 getNewLocation() {
        return new Vector3(teleportX, teleportY, 0);
    }

    public void unlockDoor() {
        if(isLocked) this.GetComponent<SpriteRenderer>().sprite = unlockedDoor;
        isLocked = false;
    }

    public void unlockOtherDoor() {
        if (isUnlockTrigger) foreach (DoorBehavior door in doorsToUnlock) door.unlockDoor();
        isUnlockTrigger = false;
    }
}

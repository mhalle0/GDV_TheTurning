using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorBehavior : MonoBehaviour
{
    public bool isLocked = true;
    public Sprite unlockedDoorImage;

    public void Update() {
        if (CureManager.Instance.playerHasCure) unlockDoor();
    }

    public void unlockDoor() {
        this.GetComponent<SpriteRenderer>().sprite = unlockedDoorImage;
        isLocked = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorBehavior : MonoBehaviour
{
    public float teleportX = 0;
    public float teleportY = 0;
    public bool isLocked = true;
    public Sprite unlockedDoorImage; //Only needs to be assigned if door is locked

    public void Update() {
        //can move if player has cure here
        if (CureManager.Instance.playerHasCure) unlockDoor();
        //Debug.Log("Usin the update on exitDoor");
    }

    public void unlockDoor() {
        if(isLocked) this.GetComponent<SpriteRenderer>().sprite = unlockedDoorImage;
        isLocked = false;
        //Debug.Log("using the unlocked door");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        /*
        if("Player".Equals(collision.gameObject.tag) && CureManager.Instance.playerHasCure) {
            //unlockDoor();
        }*/
    }
}

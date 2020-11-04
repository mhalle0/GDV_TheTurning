using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public float teleportX = 0;
    public float teleportY = 0;

    public Vector3 getNewLocation() {
        return new Vector3(teleportX, teleportY, 0);
    }
}

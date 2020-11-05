using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PillBehavior : MonoBehaviour
{
    [SerializeField] private PlayerControls player;

    void Awake()
    {

    }

    public void OnMouseDown()
    {
        if(player.pillCount > 0){
            player.TakePill();
        }
    }


}

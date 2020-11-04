using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PillBehavior : MonoBehaviour
{
    [SerializeField] private PlayerControls player;

    void Awake()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("got mouse click");
        player.TakePill();
    }


}

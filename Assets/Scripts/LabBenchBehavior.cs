using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabBenchBehavior : MonoBehaviour
{
    
    [SerializeField] private PlayerControls player;

    GameObject mapIngredient1;
    GameObject mapIngredient2;
    GameObject mapIngredient3;
    GameObject mapIngredient4;
    GameObject slotIngredient1;
    GameObject slotIngredient2;
    GameObject slotIngredient3;
    GameObject slotIngredient4;

    public bool cureReady;

    void Start()
    {
        mapIngredient1 = GameObject.Find("Ingredient1");
        mapIngredient2 = GameObject.Find("Ingredient2");
        mapIngredient3 = GameObject.Find("Ingredient3");
        mapIngredient4 = GameObject.Find("Ingredient4");

        slotIngredient1 = GameObject.Find("InvSlot1");
        slotIngredient2 = GameObject.Find("InvSlot2");
        slotIngredient3 = GameObject.Find("InvSlot3");
        slotIngredient4 = GameObject.Find("InvSlot4");

        cureReady = false;
    }

    void checkCure()
    {
        if(!mapIngredient1.activeInHierarchy && 
           !mapIngredient2.activeInHierarchy && 
           !mapIngredient3.activeInHierarchy && 
           !mapIngredient4.activeInHierarchy){
            cureReady = true;
        }
    }

    public void makeCure()
    //send log messages to dialogue box instead, when that's implemented
    {
        checkCure();
        if(cureReady){
            player.hasCure = true;
            slotIngredient1.GetComponent<Image>().enabled = false;
            slotIngredient2.GetComponent<Image>().enabled = false;
            slotIngredient3.GetComponent<Image>().enabled = false;
            slotIngredient4.GetComponent<Image>().enabled = false;
            Debug.Log("You've made the cure! Escape the hospital and bring it home to your child.");
        } else {
            Debug.Log("You don't have enough ingredients to finish the cure yet.");
        }
    }

}

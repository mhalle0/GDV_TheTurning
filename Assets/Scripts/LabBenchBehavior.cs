using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabBenchBehavior : MonoBehaviour
{

    GameObject slotIngredient1;
    GameObject slotIngredient2;
    GameObject slotIngredient3;
    GameObject slotIngredient4;
    public Sprite cureImage;

    public bool cureReady;

    void Start()
    {
        slotIngredient1 = GameObject.Find("InvSlot1");
        slotIngredient2 = GameObject.Find("InvSlot2");
        slotIngredient3 = GameObject.Find("InvSlot3");
        slotIngredient4 = GameObject.Find("InvSlot4");

        cureReady = false;
    }

    void checkCure()
    {
        //if(CureManager.Instance.circuitIsWon && 
        //   CureManager.Instance.sliderIsWon && 
        //   CureManager.Instance.codebreakingIsWon && 
        //   CureManager.Instance.mazeIsWon)
        //   {
        //       cureReady = true;
        //   }
        cureReady = true;
    }

    public void makeCure()
    //send log messages to dialogue box instead, when that's implemented
    {
        checkCure();
        if(cureReady){
            CureManager.Instance.playerHasCure = true;
            slotIngredient1.GetComponent<Image>().enabled = false;
            slotIngredient2.GetComponent<Image>().enabled = false;
            slotIngredient3.GetComponent<Image>().enabled = false;
            slotIngredient4.GetComponent<Image>().enabled = false;
            slotIngredient1.GetComponent<Image>().sprite = cureImage;
            slotIngredient1.GetComponent<Image>().enabled = true;
            Debug.Log("You've made the cure! Escape the hospital and bring it home to your child.");
        } else {
            Debug.Log("You don't have enough ingredients to finish the cure yet.");
        }
    }

}

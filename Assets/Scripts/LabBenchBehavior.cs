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

    public DialogueBehavior DialogueBox;
    //public ListBehavior List;

    public bool cureReady; 

    void Start()
    {
        slotIngredient1 = GameObject.Find("InvSlot1");
        slotIngredient2 = GameObject.Find("InvSlot2");
        slotIngredient3 = GameObject.Find("InvSlot3");
        slotIngredient4 = GameObject.Find("InvSlot4");

        DialogueBox = GameObject.Find("DialogueBox").GetComponent<DialogueBehavior>();
        //List = GameObject.Find("CureList").GetComponent<ListBehavior>();

        cureReady = false;
    }

    public bool hasIngredients()
    {
        return (CureManager.Instance.circuitIsWon &&
           CureManager.Instance.sliderIsWon &&
           CureManager.Instance.codebreakingIsWon &&
           CureManager.Instance.mazeIsWon);
    }

    void checkCure()
    {

        // changing this to independent function:
        //if (CureManager.Instance.circuitIsWon &&
        //   CureManager.Instance.sliderIsWon &&
        //   CureManager.Instance.codebreakingIsWon &&
        //   CureManager.Instance.mazeIsWon)
        if (hasIngredients())
        {
            cureReady = true;
        }
    }

    public void makeCure()
    //send log messages to dialogue box instead, when that's implemented
    {
        checkCure();
        if (cureReady)
        {
            CureManager.Instance.playerHasCure = true;
            slotIngredient1.GetComponent<Image>().enabled = false;
            slotIngredient2.GetComponent<Image>().enabled = false;
            slotIngredient3.GetComponent<Image>().enabled = false;
            slotIngredient4.GetComponent<Image>().enabled = false;
            slotIngredient1.GetComponent<Image>().sprite = cureImage;
            slotIngredient1.GetComponent<Image>().enabled = true;

            DialogueBox.QueueDialogue(new KeyValuePair<int, string>(4, "\"I got it, I got the cure! Now I just have to find a way out of here...\""));

            Debug.Log("You've made the cure! Escape the hospital and bring it home to your child.");
        }
        else
        {
            Debug.Log("You don't have enough ingredients to finish the cure yet.");
            DialogueBox.QueueDialogue(new KeyValuePair<int, string>(4, "\"Looks like I don't have all the ingredients for the cure yet. Better keep looking.\""));
        }
    }

}

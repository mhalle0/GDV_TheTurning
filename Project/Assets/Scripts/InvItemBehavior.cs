using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvItemBehavior : MonoBehaviour
{

    [SerializeField] private PlayerControls player;

    GameObject mapIngredient1;
    GameObject slotIngredient1;
    GameObject mapIngredient2;
    GameObject slotIngredient2;
    GameObject mapIngredient3;
    GameObject slotIngredient3;
    GameObject mapIngredient4;
    GameObject slotIngredient4;
    GameObject mapPillBottle;
    GameObject mapCureList;
    GameObject slotCureList;

    bool ingredient1Given;
    bool ingredient2Given;
    bool ingredient3Given;


    [SerializeField] public string puzzle;   //Used by PlayerControls to choose the puzzle to load
    [SerializeField] public ListBehavior listBtn;
    
    public void pickUp(string itemID){
        if(itemID == "pillBottle"){
            Debug.Log("Picked up pills");
            player.RefillPills();
            mapPillBottle.SetActive(false);
        }
        else if (itemID == "cureList"){
            slotCureList.GetComponent<Image>().enabled = true;
            mapCureList.SetActive(false);
            listBtn.pickedUp = true;
        }
        else if (itemID == "ingredient4"){
            CureManager.Instance.mazeIsWon = true;
            slotIngredient4.GetComponent<Image>().enabled = true;
            mapIngredient4.SetActive(false);
        }
    }

    public void getIngredient(string itemID)
    {
        if (itemID == "ingredient1"){
            slotIngredient1.GetComponent<Image>().enabled = true;
            mapIngredient1.SetActive(false);
        }
        else if (itemID == "ingredient2"){
            slotIngredient2.GetComponent<Image>().enabled = true;
            mapIngredient2.SetActive(false);
        }
        else if (itemID == "ingredient3"){
            slotIngredient3.GetComponent<Image>().enabled = true;
            mapIngredient3.SetActive(false);
        }
    }

    void Start()
    {
        mapIngredient1 = GameObject.Find("Ingredient1");
        slotIngredient1 = GameObject.Find("InvSlot1");
        slotIngredient1.GetComponent<Image>().enabled = false;

        mapIngredient2 = GameObject.Find("Ingredient2");
        slotIngredient2 = GameObject.Find("InvSlot2");
        slotIngredient2.GetComponent<Image>().enabled = false;

        mapIngredient3 = GameObject.Find("Ingredient3");
        slotIngredient3 = GameObject.Find("InvSlot3");
        slotIngredient3.GetComponent<Image>().enabled = false;

        mapIngredient4 = GameObject.Find("Ingredient4");
        slotIngredient4 = GameObject.Find("InvSlot4");
        slotIngredient4.GetComponent<Image>().enabled = false;

        mapCureList = GameObject.Find("CureList");
        slotCureList = GameObject.Find("ListSlot");
        slotCureList.GetComponent<Image>().enabled = false;

        mapPillBottle = GameObject.Find("MapPillBottle");

        ingredient1Given = false;
        ingredient2Given = false;
        ingredient3Given = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ingredient1Given == false && CureManager.Instance.sliderIsWon == true)
        {
            getIngredient("ingredient1");
            ingredient1Given = true;
        }
        if(ingredient2Given == false && CureManager.Instance.circuitIsWon == true)
        {
            getIngredient("ingredient2");
            ingredient2Given = true;
        }
        if(ingredient3Given == false && CureManager.Instance.codebreakingIsWon == true)
        {
            getIngredient("ingredient3");
            ingredient3Given = true;
        }
    }
}

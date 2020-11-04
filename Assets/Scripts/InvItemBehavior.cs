using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvItemBehavior : MonoBehaviour
{
    GameObject mapIngredient1;
    GameObject slotIngredient1;
    GameObject mapIngredient2;
    GameObject slotIngredient2;
    GameObject mapIngredient3;
    GameObject slotIngredient3;
    GameObject mapIngredient4;
    GameObject slotIngredient4;
    
    public void pickUp(string itemID){
        if(itemID == "pillBottle"){
            Debug.Log("Picked up pills");
            //add to inventory pill count, remove item from map
        }
        else if (itemID == "cureList"){
            Debug.Log("Picked up cure list");
            //add to inventory, remove item from map
        }
        else if (itemID == "ingredient1"){
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
        else if (itemID == "ingredient4"){
            slotIngredient4.GetComponent<Image>().enabled = true;
            mapIngredient4.SetActive(false);
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

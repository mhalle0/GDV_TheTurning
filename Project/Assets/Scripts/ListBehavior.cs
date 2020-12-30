using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListBehavior : MonoBehaviour
{
    public bool pickedUp;
    GameObject magnifyList;
    public DialogueBehavior DialogueBox;

    private bool clickedOn;

    // Start is called before the first frame update
    void Start()
    {
        pickedUp = false;
        clickedOn = false;
        magnifyList = GameObject.Find("ClickedList");
        magnifyList.GetComponent<Image>().enabled = false;
        DialogueBox = GameObject.Find("DialogueBox").GetComponent<DialogueBehavior>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenList()
    {
        Debug.Log("opening list");
        magnifyList.GetComponent<Image>().enabled = true;
        if (!clickedOn)
        {
            DialogueBox.QueueDialogue(new KeyValuePair<int, string>(6, "\"A cure? The Turning? Is that what's happening to me? I've gotta get these ingredients before time runs out.\""));
        }
    }

    public void CloseList()
    {
        Debug.Log("closing list");
        magnifyList.GetComponent<Image>().enabled = false;
    }
}
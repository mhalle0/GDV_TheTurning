using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListBehavior : MonoBehaviour
{
    public bool pickedUp;
    GameObject magnifyList;

    // Start is called before the first frame update
    void Start()
    {
        pickedUp = false;
        magnifyList = GameObject.Find("ClickedList");
        magnifyList.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenList()
    {
        Debug.Log("opening list");
        magnifyList.GetComponent<Image>().enabled = true;
    }

    public void CloseList()
    {
        Debug.Log("closing list");
        magnifyList.GetComponent<Image>().enabled = false;
    }
}

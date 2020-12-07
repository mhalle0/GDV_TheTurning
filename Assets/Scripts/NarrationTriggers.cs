using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationTriggers : MonoBehaviour
{
    [SerializeField] public string msg;
    //[SerializeField] public string requirement;
    [SerializeField] public bool UsesEnteredLab;
    [SerializeField] public bool EnteredLab;


    public NarrationManager narrationManager;
    private DialogueBehavior DialogeBox;

    // Start is called before the first frame update
    void Start()
    {
        DialogeBox = GameObject.Find("DialogueBox").GetComponent<DialogueBehavior>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if(UsesEnteredLab && !EnteredLab)
        //{
        //    DialogeBox.DialogueMessage(msg);
        //    EnteredLab = true;
        //}
        DialogeBox.DialogueMessage(msg);
    }
}
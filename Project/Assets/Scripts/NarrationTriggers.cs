using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationTriggers : MonoBehaviour
{
    public string msg;
    public int time;

    public List<bool> reqs = new List<bool>();

    [SerializeField] public bool uses_hasNotEnteredLab;

    private DialogueBehavior DialogueBox;

    void Start()
    {
        DialogueBox = GameObject.Find("DialogueBox").GetComponent<DialogueBehavior>();
    }

    void collectRequirements()
    {
        reqs.Clear();
        if(uses_hasNotEnteredLab == true) reqs.Add(DialogueManager.Instance.hasNotEnteredLab);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collectRequirements();
        if((reqs.Count == 0) || !reqs.Contains(false))
        {
            DialogueBox.QueueDialogue(new KeyValuePair <int, string>(time, msg));
            if(reqs.Contains(DialogueManager.Instance.hasNotEnteredLab)) DialogueManager.Instance.hasNotEnteredLab = false;
        }
    }
}
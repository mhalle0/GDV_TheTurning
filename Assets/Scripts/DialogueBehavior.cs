using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBehavior : MonoBehaviour
{
    public TMP_Text dialogue;
    public Canvas box;
    public CanvasGroup boxCG;

    void Start()
    {
        StartCoroutine("PlayDialogue");
    }

    void FixedUpdate()
    {
        if(FreezePlayer.Instance.puzzleIsOpen == true)
        {
            boxCG.alpha = 0;
            DialogueManager.Instance.dq.Clear();
        }
    }

    public void DialogueMessage(string msg)
    {
        dialogue.text = msg;
    }

    public void HideDialogueBox()
    {
        StartCoroutine("FadeOutDialogueBox");
    }
    public void ShowDialogueBox()
    {
        StartCoroutine("FadeInDialogueBox");
    }

    IEnumerator HideDialogueAfter(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideDialogueBox();	
    }

    public void QueueDialogue(KeyValuePair<int, string> kv){
        DialogueManager.Instance.dq.Enqueue(kv);
    }

    public IEnumerator PlayDialogue()
    {
        while(true)
        {
            yield return new WaitUntil(() => (DialogueManager.Instance.dq.Count > 0));
            while(DialogueManager.Instance.dq.Count > 0)
            {
                var dequeued = DialogueManager.Instance.dq.Dequeue();
                ShowDialogueBox();
                DialogueMessage(dequeued.Value);
                yield return new WaitForSeconds(dequeued.Key);
                HideDialogueBox();
            }
        }
    }

    public IEnumerator FadeOutDialogueBox() 
    {
        float timePassed = 0;
        float duration = 1.5f;
        while (timePassed <= duration) 
        {
            timePassed += Time.deltaTime;
            //Debug.Log("time passed: " + timePassed + " out of " + duration);
            boxCG.alpha = Mathf.Lerp(1, 0, timePassed / duration);                      //Mathf.Lerp(1f, 0f, elapsedTime / duration);
            yield return null;
        }
        boxCG.alpha = 0f;
    }

    public IEnumerator FadeInDialogueBox() 
    {
        float timePassed = 0;
        float duration = 1.5f;
        while (timePassed <= duration) 
        {
            timePassed += Time.deltaTime;
            //Debug.Log("time passed: " + timePassed + " out of " + duration);
            boxCG.alpha = Mathf.Lerp(0, 1, timePassed / duration);                      //Mathf.Lerp(1f, 0f, elapsedTime / duration);
            yield return null;
        }
        boxCG.alpha = 1f;
    }

}

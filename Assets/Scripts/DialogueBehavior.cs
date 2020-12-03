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
        DialogueMessage("Example call to DialogueMessage() function");
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

    public IEnumerator FadeOutDialogueBox() 
    {
        float timePassed = 0;
        float duration = 1.5f;
        while (timePassed <= duration) 
        {
            timePassed += Time.deltaTime;
            Debug.Log("time passed: " + timePassed + " out of " + duration);
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
            Debug.Log("time passed: " + timePassed + " out of " + duration);
            boxCG.alpha = Mathf.Lerp(0, 1, timePassed / duration);                      //Mathf.Lerp(1f, 0f, elapsedTime / duration);
            yield return null;
        }
        boxCG.alpha = 1f;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleFunctions : MonoBehaviour
{

    public void Exit()
    {
        SceneManager.UnloadSceneAsync("PuzzleTemplate");
    }

    public void Retry()
    {
        // redo puzzle
    }

    public void Win()
    {

    }

    public void OnMouseDown()
    {
        if (this.gameObject.name == "ExitBtn")
        {
            Debug.Log("tryna close");
            Exit();
        }
        
        else if (this.gameObject.name == "RetryBtn")
        {
            Debug.Log("clicked retry btn");
            Retry();
        }
           
    }
}

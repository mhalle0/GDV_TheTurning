using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleExit : MonoBehaviour
{
    public string puzzleSceneName;

    public void OnMouseDown()
    {
        if (puzzleSceneName == null) SceneManager.UnloadSceneAsync("PuzzleTemplate");
        else SceneManager.UnloadSceneAsync(puzzleSceneName);
        FreezePlayer.Instance.puzzleIsOpen = false;
        //SceneManager.LoadScene("Hospital");
        //SceneManager.LoadScene(0);
    }

}
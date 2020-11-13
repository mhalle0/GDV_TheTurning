using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    Scene MainScene;

    // Use this for initialization
    void Start()
    {
        MainScene = SceneManager.GetSceneByName("Hospital");
    }

    public void ActivatePuzzle(string Puzzle)
    {
        MainScene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(Puzzle);
        //SceneManager.LoadScene(Puzzle, LoadSceneMode.Single);
    }

    //public void ExitPuzzle()
    //{
    //    SceneManager.LoadSceneAsync(MainScene.name);
    //}

}

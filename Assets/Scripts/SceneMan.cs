using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    Scene MainScene;
    [SerializeField] GameObject player;

    // Use this for initialization
    void Start()
    {
        MainScene = SceneManager.GetSceneByName("Hospital");
    }

    public void ActivatePuzzle(string Puzzle)
    {
        MainScene = SceneManager.GetActiveScene();

        Scene PuzzleScene = SceneManager.GetSceneByName(Puzzle);
        

        //SceneManager.LoadSceneAsync(Puzzle, LoadSceneMode.Additive);

        SceneManager.LoadScene(Puzzle, LoadSceneMode.Additive);
    }

}

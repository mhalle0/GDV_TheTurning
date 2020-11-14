using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PuzzleExit : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.UnloadSceneAsync("PuzzleTemplate");
        //SceneManager.LoadScene("Hospital");
        //SceneManager.LoadScene(0);
    }

}
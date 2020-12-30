using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuScript : MonoBehaviour
{

    public void WinOpenInfo()
    {
        Debug.Log("Info button clicked from win menu");
        SceneManager.LoadScene("InfoMenu");
    }

    public void WinPlayAgain()
    {
        Debug.Log("Play again button clicked from win menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void WinExit()
    {
        Debug.Log("Game quit from win menu");
        Application.Quit();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{

    [SerializeField] private PlayerControls player;

    public void PauseResume()
    {
        Debug.Log("Pause resume button clicked");
        player.TogglePause();
    }

    public void PauseExit()
    {
        Debug.Log("Exit clicked from pause menu");
        Application.Quit();
    }

    public void PauseStartOver()
    {
        Debug.Log("Start over clicked from pause menu");
        player.TogglePause();
        SceneManager.LoadScene("MainMenu");
    }
}

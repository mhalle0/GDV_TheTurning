using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Hospital");
    }

    public void ClickInfo()
    {
        Debug.Log("Info button clicked");
        SceneManager.LoadScene("InfoMenu");
    }
}

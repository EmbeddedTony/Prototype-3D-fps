using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    
    public void LoadMainGame()
    {
        SceneManager.LoadScene("level00");
    }

    public void QuitApp()
    {
        Application.Quit();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loadScene : MonoBehaviour
{
    
    public void sceneLoader()
    {
        SceneManager.UnloadSceneAsync("mainMenu");
        SceneManager.LoadScene("homeMenu");
    }

    
}

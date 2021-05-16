using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPress : MonoBehaviour
{
    public GameObject Menu;
    public GameObject pAnythingScreen;

    


   
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(goMenu());
        }
    }

    IEnumerator goMenu()
    {
        pAnythingScreen.SetActive(false);
        Debug.Log("pre pre");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Pre");
        Menu.SetActive(true);
        Debug.Log("Worked");
    }

}

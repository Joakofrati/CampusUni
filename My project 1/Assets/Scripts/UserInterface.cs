using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    public void logIn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void logOut()
    {
        Application.Quit();
        Debug.Log("OUT");
    }

}

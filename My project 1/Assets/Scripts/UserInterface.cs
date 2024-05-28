using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    public GameObject nicknameScreen;
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    public void logIn()
    {
        nicknameScreen.SetActive(true);
        //SceneManager.LoadScene("SampleScene");

    }

    public void logOut()
    {
        Application.Quit();
        Debug.Log("OUT");
    }

}

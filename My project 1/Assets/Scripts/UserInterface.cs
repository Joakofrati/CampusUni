using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    //   public GameObject nicknameScreen;
    public GameObject selectCharacterScreen;
    private RoomManager roomManager;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void logIn()
    {
        bool volviMenuPrincipal = PlayerPrefs.GetInt("VolviMenuPrincipal", 0) == 1;
        Debug.Log(volviMenuPrincipal);
        roomManager = FindObjectOfType<RoomManager>();
        Debug.Log("RM " + roomManager);
        if (volviMenuPrincipal)
        {
            roomManager.JoinRoomButton();
        }
        else
        {
            selectCharacterScreen.SetActive(true);
        }

    }

    public void logOut()
    {
        Application.Quit();
        Debug.Log("OUT");
    }

}

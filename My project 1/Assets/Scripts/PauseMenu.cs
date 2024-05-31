using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPause;
    public GameObject player;


    void Start()
    {
        PlayerPrefs.SetInt("VolviMenuPrincipal", 0);
        player = GameObject.FindGameObjectWithTag("Player");
        pausePanel.SetActive(false);
        isPause = false;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && (!isPause))
        {
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<PlayerMove>().canMoveToggle(false);
            Cursor.visible = true;
            pausePanel.SetActive(true);
            isPause = true;
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        isPause = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<PlayerMove>().canMoveToggle(true);
        Cursor.visible = false;
    }

    public void BackToPrincipalMenu()
    {
        PlayerPrefs.SetInt("VolviMenuPrincipal", 1);
        SceneManager.LoadScene("UserInterface");
        DisconnectFromRoom();
    }

    public void LogOut()
    {
        Application.Quit();
        Debug.Log("OUT");
    }

    public void DisconnectFromRoom()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.LeaveLobby();
        }
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }

    }

}

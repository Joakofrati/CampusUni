using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ButtonHome : MonoBehaviourPunCallbacks
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("UserInterface");
            DisconnectFromRoom();

        }
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

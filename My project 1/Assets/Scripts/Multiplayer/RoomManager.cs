using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public PhotonView player;
    [Space]
    public Transform spawnPoint;

    [Space]
    public GameObject roomCam;
    [Space]
    public GameObject nameUI;
    public GameObject connectingUI;

    private string nickname = "unnamed";

    // public void Update()
    //{
    //  if (Input.GetKeyDown(KeyCode.Escape))
    // {
    //    DisconnectFromRoom();
    //}
    //}

    public void DisconnectFromRoom()
    {
        if (PhotonNetwork.InRoom)
        {
            Debug.Log("LEAVE ROOM");
            PhotonNetwork.LeaveRoom();
        }

    }

    public void ChangeNickname(string name)
    {
        nickname = name;
    }

    public void JoinRoomButton()
    {
        Debug.Log("Connecting...");

        //   if (PhotonNetwork.IsConnected) {
        //       PhotonNetwork.JoinOrCreateRoom("test", null, null);
        //   }

        PhotonNetwork.ConnectUsingSettings();
        nameUI.SetActive(false);
        PhotonNetwork.NickName = nickname;
        connectingUI.SetActive(true);
      //  CargarEscena();
        

    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected to Server.");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("test", null, null);

        Debug.Log("You're in Lobby");
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("You're in a Room");
        //    roomCam.SetActive(false);

        GameObject playerClone = PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation);
        DontDestroyOnLoad(playerClone);
        Debug.Log(player.name);

        playerClone.tag = "Player";
        playerClone.transform.Find("MiniMapPlayer").gameObject.SetActive(true);
        playerClone.transform.Find("MapMark").gameObject.SetActive(true);
        playerClone.transform.Find("MiniMapMark").gameObject.SetActive(true);
        

        PhotonNetwork.LoadLevel("SampleScene");
    }
}
    

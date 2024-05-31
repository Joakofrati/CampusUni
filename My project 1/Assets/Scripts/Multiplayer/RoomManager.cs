using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public PhotonView player;
    public Transform spawnPoint;
    public GameObject roomCam;
    public GameObject nameUI;
    public GameObject connectingUI;

    public GameObject[] characterPrefabs;

    private string nickname = "unnamed";

    public void ChangeNickname(string name)
    {
        nickname = name;
    }

    public void JoinRoomButton()
    {
        Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();
        nameUI.SetActive(false);
        PhotonNetwork.NickName = nickname;
        if (nickname == "unnamed")
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");
        }
        else
        {
            PlayerPrefs.SetString("NickName", nickname);
        }
        connectingUI.SetActive(true);
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
        Debug.Log("Entro ONJOINEDROOM");

        if (PlayerPrefs.HasKey("SelectedCharacterIndex"))
        {
            int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");
            GameObject playerClone = PhotonNetwork.Instantiate(characterPrefabs[selectedCharacterIndex].name, spawnPoint.position, spawnPoint.rotation);

            DontDestroyOnLoad(playerClone);

            playerClone.tag = "Player";
            playerClone.transform.Find("MiniMapPlayer").gameObject.SetActive(true);
            playerClone.transform.Find("MapMark").gameObject.SetActive(true);
            playerClone.transform.Find("MiniMapMark").gameObject.SetActive(true);


            PhotonNetwork.LoadLevel("SampleScene");
        }
        else
        {
            Debug.LogWarning("SelectedCharacterIndex not found. Character selection may not have been completed.");
        }
    }
}


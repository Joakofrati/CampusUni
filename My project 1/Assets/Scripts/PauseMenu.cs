using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject cameraMap;
    public GameObject player;
    public GameObject canvasBlueBus;
    public GameObject canvasRedBus;
    public GameObject canvasBrownBus;
    public GameObject mapCanvas;
    public GameObject canvasInteract;

    public bool isPause;
    private PostProcessVolume ppVolumeFirstPerson;
    private PostProcessVolume ppVolumeThirdPerson;
    private GameObject miniMapCamera;
    private Interactor interactorScript;
    private bool isMapActive = false;
    private bool isBlueBusActive = false;
    private bool isBrownBusActive = false;
    private bool isRedBusActive = false;

    void Start()
    {
        PlayerPrefs.SetInt("VolviMenuPrincipal", 0);
        player = GameObject.FindGameObjectWithTag("Player");
        interactorScript = player.GetComponent<Interactor>();
        GameObject playerCamera = player.transform.Find("Camera").gameObject;
        GameObject playerCamera3ra = player.transform.Find("Camera3ra").gameObject;
        ppVolumeFirstPerson = playerCamera.GetComponent<PostProcessVolume>();
        ppVolumeThirdPerson = playerCamera3ra.transform.GetComponent<PostProcessVolume>();
        miniMapCamera = player.transform.Find("MiniMapPlayer").gameObject;
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
            ppVolumeFirstPerson.enabled = true;
            ppVolumeThirdPerson.enabled = true;
            interactorScript.ForPauseMenu();
            interactorScript.enabled = false;
            if (cameraMap.activeInHierarchy)
            {
                //Sincronización si el mapa esta activado
                mapCanvas.SetActive(false);
                isMapActive = true;
            }
            else if (canvasBlueBus.activeInHierarchy)
            {
                canvasBlueBus.SetActive(false);
                miniMapCamera.SetActive(false);
                isBlueBusActive = true;
            }
            else if (canvasBrownBus.activeInHierarchy)
            {
                canvasBrownBus.SetActive(false);
                miniMapCamera.SetActive(false);
                isBrownBusActive = true;
            }
            else if (canvasRedBus.activeInHierarchy)
            {
                canvasRedBus.SetActive(false);
                miniMapCamera.SetActive(false);
                isRedBusActive = true;
            }
            else
            {
                //Decidi desactivar el minimap en la pausa me parecio que quedaba mejor se puede modificar
                miniMapCamera.SetActive(false);
                if (canvasInteract.activeInHierarchy)
                {
                    canvasInteract.SetActive(false);
                }
            }
            pausePanel.SetActive(true);
            isPause = true;
            
        }
    }

    public void Resume()
    {
        ppVolumeFirstPerson.enabled = false;
        ppVolumeThirdPerson.enabled = false;
        interactorScript.enabled = true;
        if (isMapActive)
        {
            //Sincronización si el mapa esta activado
            mapCanvas.SetActive(true);
            isMapActive = false;
            Cursor.visible = true;
        }
        else if (isBlueBusActive){
            miniMapCamera.SetActive(true);
            canvasBlueBus.SetActive(true);
            isBlueBusActive = false;
            Cursor.visible = true;
        }
        else if (isBrownBusActive)
        {
            miniMapCamera.SetActive(true);
            canvasBrownBus.SetActive(true);
            isBrownBusActive = false;
            Cursor.visible = true;
        }
        else if (isRedBusActive)
        {
            miniMapCamera.SetActive(true);
            canvasRedBus.SetActive(true);
            isRedBusActive = false;
            Cursor.visible = true;
        }
        else
        {
            //Sincronización si el mapa está desactivado, activación del minimap
            miniMapCamera.SetActive(true);
            if (canvasInteract.activeInHierarchy)
            {
                canvasInteract.SetActive(true);
            }
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<PlayerMove>().canMoveToggle(true);
            Cursor.visible = false;
        }
        pausePanel.SetActive(false);
        isPause = false;
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

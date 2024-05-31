using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LimitCamera : MonoBehaviourPunCallbacks
{
    public GameObject Player
    ;
    private void Start()
    {
        Debug.Log("LIMIT CAMERA " + Player.name);
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate(){

        Vector3 currentPosition = gameObject.GetComponent<Transform>().position;
        transform.position = new Vector3(Player
        .transform.position.x,currentPosition.y, Player
        .transform.position.z);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class SetNickname : MonoBehaviourPunCallbacks
{

    void Start()
    {
        GetComponent<TextMeshPro>().text = photonView.Owner.NickName;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class SetNickname : MonoBehaviourPunCallbacks
{
    void Start()
    {
        GetComponent<TextMeshPro>().text = photonView.Owner.NickName;
    }
}

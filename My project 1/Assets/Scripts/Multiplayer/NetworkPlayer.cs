using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviourPunCallbacks, IPunObservable
{
    Vector3 realPosition = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;

    void Update()
    {
        if (photonView.IsMine)
        {
            //Do nothing
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, realPosition, 1.8f);
            transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 1.8f);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //This is OUR player position.
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            //This is someone else's player.
            realPosition = (Vector3)stream.ReceiveNext();
            realRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}

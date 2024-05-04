using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCamera : MonoBehaviour
{
    public GameObject Player
    ;

    private void LateUpdate(){
        Vector3 currentPosition = gameObject.GetComponent<Transform>().position;
        transform.position = new Vector3(Player
        .transform.position.x,currentPosition.y, Player
        .transform.position.z);
        
    }
}

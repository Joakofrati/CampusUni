using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rendering : MonoBehaviour
{
    public GameObject player;
    public GameObject edificio;
    public float distance = 120f;
    private float distancia;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distancia = Mathf.Sqrt(Mathf.Pow(player.GetComponent<Transform>().position.x - edificio.GetComponent<Transform>().position.x,2) + 
            Mathf.Pow(player.GetComponent<Transform>().position.y - edificio.GetComponent<Transform>().position.y,2) + 
            Mathf.Pow(player.GetComponent<Transform>().position.z - edificio.GetComponent<Transform>().position.z,2));
        if (distancia > distance){
            edificio.active = false;
        } else {
            edificio.active = true;
        }
        // Debug.Log("Distancia = " + distancia);
    }
}

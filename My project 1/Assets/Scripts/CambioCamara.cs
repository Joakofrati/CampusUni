using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    public Transform pos1, pos2;

    private bool vista;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            vista = true;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            vista = false;
        }

        if (vista == true)
        {
            transform.position = Vector3.Lerp(transform.position, pos1.position, 5 * Time.deltaTime);
        } else
        {
            transform.position = Vector3.Lerp(transform.position, pos2.position, 5 * Time.deltaTime);
        }
    }
}

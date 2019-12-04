using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : MonoBehaviour
{

    public CameraController cam;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wubs")
        {
            cam.SetSize(26);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Wubs")
        {
            cam.SetSize(18);
        }
    }
}

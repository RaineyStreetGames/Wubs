using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : MonoBehaviour
{
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wubs")
        {
            CameraController.TargetSize = 26;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Wubs")
        {
            CameraController.TargetSize = 18;
        }
    }
}

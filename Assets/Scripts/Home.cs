using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{

    public GameObject Room;

    public bool displayed;
    public SpriteRenderer[] renderers;

    void Start()
    {
        renderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        float a = Time.deltaTime / 0.5f;
        foreach (SpriteRenderer sr in renderers)
        {
            if (displayed && sr.color.a < 1.0f)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + a);
            }
            else if (!displayed && sr.color.a > 0.0f)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - a);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wubs")
        {
            displayed = false;
            // foreach (var spriteRenderer in renderers)
            // {
            //     StartCoroutine(spriteRenderer.FadeOut(0.5f));
            // }
            CameraController.TargetSize = 8;
            CameraController.MinY = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Wubs")
        {
            if (!other.IsTouching(Room.GetComponent<Collider2D>()))
            {
                displayed = true;
                // foreach (var spriteRenderer in renderers)
                // {
                //     StartCoroutine(spriteRenderer.FadeIn(0.5f));
                // }
                CameraController.TargetSize = 18;
                CameraController.MinY = -7;
            }
        }
    }
}

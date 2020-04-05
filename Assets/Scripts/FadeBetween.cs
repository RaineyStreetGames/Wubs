using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBetween : MonoBehaviour
{

    private bool fade;
    private float fadeTime;
    private bool delay;
    private float delayTime;

    SpriteRenderer sr;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        Reset();
    }

    void Reset()
    {
        fade = true;
        fadeTime = Random.Range(0.25f, 2.25f);
        delay = false;
        delayTime = Random.Range(2f, 6f);
    }

    void FixedUpdate()
    {
        float a = Time.deltaTime / fadeTime;
        if (fade)
        {
            if (sr.color.a <= 1.0f)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + a);
            }
            else
            {
                fade = false;
            }
        }
        else
        {
            if (sr.color.a >= 0.0f)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - a);
            }
            else
            {
                delay = true;
            }
        }

        if (delay)
        {
            delayTime -= Time.deltaTime;
            if (delayTime <= 0.0f)
            {
                Reset();
            }
        }
    }
}

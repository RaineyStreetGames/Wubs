using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0);
        StartCoroutine(SpriteHelper.FadeIn(renderer, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnDestroy()
    {

    }

    void OnJointBreak2D(Joint2D brokenJoint)
    {
        // Debug.Log("A joint has just been broken!");
        StartCoroutine(SpriteHelper.FadeOut(GetComponent<SpriteRenderer>(), 1.0f));
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(this.gameObject, 1.0f);

        // StartCoroutine(SpriteHelper.FadeOut(brokenJoint.connectedBody.GetComponent<SpriteRenderer>(), 1.0f));
        // brokenJoint.connectedBody.GetComponent<BoxCollider2D>().enabled = false;
        // Destroy(brokenJoint.connectedBody, 1.0f);
    }
}

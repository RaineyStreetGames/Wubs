using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBetween : MonoBehaviour
{
    public float xMinScale;
    public float xMaxScale;
    public float yMinScale;
    public float yMaxScale;

    private Vector3 scaleTarget;
    private Vector3 initScale;
    private bool enableScale;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
        scaleTarget = transform.localScale;
        initScale = transform.localScale;

        var renderer = GetComponentInChildren<SpriteRenderer>();
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0);
        StartCoroutine(SpriteHelper.FadeIn(renderer, 1.0f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, scaleTarget, speed);

        if (transform.localScale == scaleTarget)
        {
            if (enableScale)
            {
                var xScale = Random.Range(xMinScale, xMaxScale);
                var yScale = Random.Range(yMinScale, yMaxScale);
                scaleTarget = new Vector3(xScale, yScale, 1);
                enableScale = false;
                speed = Random.Range(0.02f, 0.05f);
            }
            else
            {
                scaleTarget = initScale;
                enableScale = true;
                speed = Random.Range(0.01f, 0.02f);
            }
        }
    }
}

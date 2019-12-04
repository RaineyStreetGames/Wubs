using UnityEngine;
using System.Collections;

public static class TransformHelper
{
    public static IEnumerator ScaleBop(this Transform transform)
    {
        var initScale = transform.localScale;
        var scaleOut = false;
        var speed = Random.Range(0.01f, 0.02f);
        var scaleTarget = transform.localScale * Random.Range(0.75f, 1.25f);

        while (true)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, scaleTarget, speed);

            if (transform.localScale == scaleTarget)
            {
                if (scaleOut)
                {
                    scaleTarget = transform.localScale * Random.Range(0.75f, 1.25f);
                    scaleOut = false;
                    speed = Random.Range(0.02f, 0.05f);
                }
                else
                {
                    scaleTarget = initScale;
                    scaleOut = true;
                    speed = Random.Range(0.01f, 0.02f);
                }
            }
        }
    }
}

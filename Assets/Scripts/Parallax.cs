using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject target;
    public float speed;
    Vector3 lastpos;

    // Start is called before the first frame update
    void Start()
    {
        lastpos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var parallax = ((lastpos - target.transform.position) * speed);
        transform.position -= new Vector3(parallax.x, 0, 0);
        lastpos = target.transform.position;
    }
}

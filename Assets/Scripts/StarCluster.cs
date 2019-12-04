using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class StarCluster : MonoBehaviour
{
    public GameObject starPiece;
    public GameObject starLight;
    private List<GameObject> stars;

    private GameObject glow;

    void Start()
    {
        glow = Instantiate(starLight, transform.position, Quaternion.Euler(0, 0, 0), transform);
        // StartCoroutine(glow.GetComponent<Transform>().ScaleBop());

        var pieces = (int)Random.Range(5, 9);
        var radians = 360 / pieces;
        for (int x = 0; x < pieces; x++)
        {
            Instantiate(starPiece, transform.position, Quaternion.Euler(0, 0, x * radians), transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision: " + gameObject.name + " hit " + collision.collider.name);
        // wubSource.clip = wubList[Random.Range(0, wubList.Count)];
        // PlaySource(wubSource, 10.0f);

    }

}
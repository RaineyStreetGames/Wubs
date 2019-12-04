using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class StarController : MonoBehaviour
{
    public GameObject starCluster;
    public static int minX = -160;
    public static int maxX = 180;
    public static int minY = 115;
    public static int maxY = 225;
    private int count = 22;

    public List<GameObject> stars;
    public LayerMask objectLayer;

    // Start is called before the first frame update
    void Start()
    {
        stars = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            initiateStar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        stars.RemoveAll(x => x == null);

        if (stars.Count() < count)
            initiateStar();

    }

    private void initiateStar()
    {
        var starX = Random.Range(minX, maxX);
        var starY = Random.Range(minY, maxY);
        var starPos = new Vector3(starX, starY, 1);

        if (Physics2D.OverlapCircle(starPos, 10.0f, objectLayer) == null)
        {
            var star = Instantiate(starCluster, starPos, Quaternion.Euler(1, 0, 0), transform);
            stars.Add(star);
        }
        // var cloudS = Random.Range(0, 2);
        // cloud.transform.localScale += new Vector3(cloudS, cloudS, cloudS);
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class CloudController : MonoBehaviour
{
    public GameObject cloud0;
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;
    public GameObject cloud4;
    public GameObject cloud5;
    public GameObject cloud6;
    public GameObject cloud7;
    public GameObject cloudCluster;
    public static int minX = -175;
    public static int maxX = 180;
    public static int minY = 40;
    public static int maxY = 75;
    public static float direction = 1.0f;
    private int count = 16;

    public static List<GameObject> cloudList;
    public List<GameObject> clusters;

    // Start is called before the first frame update
    void Start()
    {
        direction = (Random.value > 0.5f) ? 1 : -1;

        cloudList = new List<GameObject>();
        cloudList.Add(cloud0);
        cloudList.Add(cloud1);
        cloudList.Add(cloud2);
        cloudList.Add(cloud3);
        cloudList.Add(cloud4);
        cloudList.Add(cloud5);
        cloudList.Add(cloud6);
        cloudList.Add(cloud7);


        clusters = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            initiateCloud();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        clusters.RemoveAll(x => x == null);

        if (clusters.Count() < count)
            initiateCloud();

    }

    private void initiateCloud()
    {
        var cloudX = Random.Range(minX, maxX);
        var cloudY = Random.Range(minY, maxY);
        var cloud = Instantiate(cloudCluster, new Vector3(cloudX, cloudY, 0.0f), Quaternion.Euler(direction, 0, 0), transform);
        clusters.Add(cloud);
        // var cloudS = Random.Range(0, 2);
        // cloud.transform.localScale += new Vector3(cloudS, cloudS, cloudS);
    }
}

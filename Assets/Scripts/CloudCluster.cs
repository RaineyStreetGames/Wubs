using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class CloudCluster : MonoBehaviour
{
    private float speed;
    private float xSpace = 2.0f;
    private float ySpace = 1.5f;
    private List<GameObject> clouds;

    void Start()
    {
        speed = Random.Range(0.005f, 0.025f);
        clouds = new List<GameObject>();
        var rows = (int)Random.Range(2, 5);
        var pieces = (int)Random.Range(2, 6);

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < pieces; x++)
            {
                var piece = CloudController.cloudList[Random.Range(0, CloudController.cloudList.Count - 1)];
                var offset = y != 0 && y != rows - 1 ? xSpace : 0;
                var variance = Random.Range(-0.5f, 0.5f);
                var cloud = Instantiate(piece, new Vector3(transform.position.x + (x * xSpace) - (offset), transform.position.y - (y * ySpace) + variance, 0.0f), Quaternion.Euler(1, 0, 0), transform);
                var joint = cloud.GetComponent<RelativeJoint2D>();
                if (clouds.Any())
                    joint.connectedBody = clouds.Last().GetComponent<Rigidbody2D>();
                clouds.Add(cloud);
            }
            pieces = Mathf.Max((int)Random.Range(pieces - 1, pieces + 1), 3);
        }

        clouds.First().GetComponent<RelativeJoint2D>().connectedBody = clouds.Last().GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < -CloudController.maxX)
        {
            transform.position = new Vector3(CloudController.maxX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > CloudController.maxX)
        {
            transform.position = new Vector3(-CloudController.maxX, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + (speed * CloudController.direction), transform.position.y, transform.position.z);
        }

        if (!clouds.Any(x =>
        {
            if (x == null)
                return false;

            var joint = x.GetComponent<RelativeJoint2D>();
            if (joint == null)
                return false;

            return joint.connectedBody != null;
        }))
        {
            // Debug.Log("Cloud cluster inactive!");
            foreach (var cloud in clouds.Where(x => x != null))
            {
                StartCoroutine(SpriteHelper.FadeOut(cloud.GetComponent<SpriteRenderer>(), 1.0f));
                cloud.GetComponent<BoxCollider2D>().enabled = false;
            }
            Destroy(this.gameObject, 1.0f);
        }
    }
}

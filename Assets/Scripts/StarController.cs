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
    public AudioClip star0;
    public AudioClip star1;
    public AudioClip star2;
    public AudioClip star3;
    public LayerMask objectLayer;

    private int count = 22;
    private static int starIndex = 0;
    private static List<AudioClip> sounds;
    private List<GameObject> stars;
    private static AudioSource starSource;

    // Start is called before the first frame update
    void Start()
    {
        stars = new List<GameObject>();
        sounds = new List<AudioClip>() { star0, star1, star2, star3 };
        starSource = GetComponent<AudioSource>();

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

    public static void CollectStar()
    {
        // if (!starSource.isPlaying)
        // {
        starSource.clip = sounds[starIndex];
        starSource.Play();
        starIndex = starIndex == (sounds.Count - 1) ? 0 : starIndex + 1;
        // }
    }
}
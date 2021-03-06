using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class StarCluster : MonoBehaviour
{
    public GameObject starPiece;
    public GameObject starLight;
    public GameObject starDust;

    private List<GameObject> stars;
    private AudioSource starSource;
    private bool collected;

    void Start()
    {
        starSource = GetComponent<AudioSource>();
        stars = new List<GameObject>();
        var glow = Instantiate(starLight, transform.position, Quaternion.Euler(0, 0, 0), transform);
        stars.Add(glow);

        var pieces = (int)Random.Range(5, 9);
        var radians = 360 / pieces;
        for (int x = 0; x < pieces; x++)
        {
            var star = Instantiate(starPiece, transform.position, Quaternion.Euler(0, 0, x * radians), transform);
            stars.Add(star);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wubs")
        {
            foreach (var star in stars.Where(x => x != null))
            {
                StartCoroutine(SpriteHelper.FadeOut(star.GetComponentInChildren<SpriteRenderer>(), 1.0f));
            }

            if (!collected)
            {
                Instantiate(starDust, transform.position, Quaternion.Euler(0, 0, 0), transform.parent);
                StarController.CollectStar(starSource);
                collected = true;
            }


            Destroy(this.gameObject, 3.75f);
        }
    }

}
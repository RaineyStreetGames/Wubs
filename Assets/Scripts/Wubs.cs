using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wubs : MonoBehaviour
{
    public float force = 0;
    public float maxSpeed = 1;
    public AudioClip wub1;
    public AudioClip wub2;
    public AudioClip wub3;
    public AudioClip wub4;
    public float targetOffset;

    private Rigidbody2D rb;
    private Vector3 target;
    private Vector3 center;
    private bool flying;
    private List<AudioClip> wubList;
    private AudioSource wubSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wubList = new List<AudioClip>() { wub1, wub2, wub3, wub4 };
        wubSource = GetComponent<AudioSource>();
        wubSource.clip = wubList[Random.Range(0, wubList.Count)];
        center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            flying = true;
            var dir = (Input.mousePosition - center) * targetOffset;
            target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x - dir.x, Input.mousePosition.y, 0));
            target = new Vector3(target.x, target.y, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            flying = false;
        }
    }

    void FixedUpdate()
    {
        if (flying)
        {
            float speed = Mathf.Min(maxSpeed, force);
            rb.AddForce((target - transform.position).normalized * force);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed);
        }
        else
        {
            rb.velocity = Vector2.MoveTowards(rb.velocity, Vector2.zero, 5);
            rb.angularVelocity = rb.velocity.x;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("collision: " + gameObject.name + " hit " + collision.collider.name);
        if (!wubSource.isPlaying)
        {
            wubSource.clip = wubList[Random.Range(0, wubList.Count)];
            wubSource.Play();
        }

    }
}

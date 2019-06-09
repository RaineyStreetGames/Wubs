using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wubs : MonoBehaviour
{

    [HideInInspector] public bool facingRight = false;
    [HideInInspector] public bool grounded = false;

    public float force = 0;
    public float maxSpeed = 1;
    public AudioClip wub1;
    public AudioClip wub2;
    public AudioClip wub3;
    public AudioClip wub4;

    private Rigidbody2D rb;
    private Vector3 target;
    private bool fly;
    private List<AudioClip> wubList;
    private AudioSource wubSource;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wubList = new List<AudioClip>();
        wubList.Add(wub1);
        wubList.Add(wub2);
        wubList.Add(wub3);
        wubList.Add(wub4);
        wubSource = GetComponent<AudioSource>();
        wubSource.clip = wubList[Random.Range(0, wubList.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Debug.Log("Mouse down. mouse: " );
            fly = true;
            // force += .1f;

            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target = new Vector3(mouse.x, mouse.y, 0);
        }

        // Mouse Up Event
        if (Input.GetMouseButtonUp(0))
        {
            fly = false;
            // force = 0;
        }
    }

    void FixedUpdate()
    {
        if (fly)
        {
            // rigidbody.gravityScale = 0.5f;
            float speed = Mathf.Min(maxSpeed, force);
            // if (rigidbody.velocity.magnitude < 50) { 
            // if (Vector3.Distance(transform.localPosition, target) > 5.0f) {
            rb.AddForce((target - transform.position).normalized * force);
            // } else {
            // 		rb.velocity = rb.velocity * 0.9f;
            // 		rb.angularVelocity = rb.angularVelocity * 0.9f;
            // }
            // }
            // if (Vector3.Distance(transform.localPosition, target) > 1.0f) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed);
            // }
        }
        else
        {
            // rigidbody.gravityScale = 1;
            rb.velocity = Vector2.MoveTowards(rb.velocity, Vector2.zero, 5);
            rb.angularVelocity = rb.velocity.x;
        }

        // if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
        // 		rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

    }

    void PlaySource(AudioSource source, float vol)
    {

        if (!source.isPlaying)
        {
            source.volume = vol;
            source.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision: " + gameObject.name + " hit " + collision.collider.name);
        wubSource.clip = wubList[Random.Range(0, wubList.Count)];
        PlaySource(wubSource, 10.0f);

    }
}

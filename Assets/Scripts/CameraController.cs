using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public static float MinY = 0;
    public static float MaxY = 275;
    public static float MinX = -155;
    public static float MaxX = 155;
    public static float TargetSize;

    private Vector3 offset;
    private Camera cam;
    private float maxDistanceRatio = 0.15f;
    private float cameraSpeed = 0.95f;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        TargetSize = cam.orthographicSize;
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;

        Vector3 target = player.transform.position + offset;
        transform.position = new Vector3(
            Mathf.Clamp(target.x, MinX + cam.orthographicSize, MaxX - cam.orthographicSize),
            Mathf.Clamp(target.y, MinY + cam.orthographicSize, MaxY - cam.orthographicSize), target.z);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        Vector3 target = player.transform.position + offset;
        float targetDistance = Vector2.Distance(target, transform.position);
        if (targetDistance >= maxDistanceRatio * cam.orthographicSize || cam.orthographicSize < 10)
        {
            float speed = cameraSpeed;
            if (targetDistance >= 0.9f * cam.orthographicSize)
            {
                speed = speed * 2;
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(
            Mathf.Clamp(target.x, MinX + cam.orthographicSize * cam.aspect, MaxX - cam.orthographicSize * cam.aspect),
            Mathf.Clamp(target.y, MinY + cam.orthographicSize, MaxY - cam.orthographicSize), target.z), speed);
        }

        if (cam.orthographicSize <= TargetSize - cameraSpeed)
        {
            cam.orthographicSize += cameraSpeed / 2.0f;
        }
        else if (cam.orthographicSize >= TargetSize + cameraSpeed)
        {
            cam.orthographicSize -= cameraSpeed / 2.0f;
        }

    }
}

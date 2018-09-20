using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;

    private Vector3 offset;
    private Camera cam;

    private float maxDistanceRatio = 0.5f;
    private float cameraSpeed = 0.5f;
    private float targetSize;

    // Use this for initialization
    void Start () 
    {
        cam = GetComponent<Camera>();
        targetSize = cam.orthographicSize;
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;

        Vector3 target = player.transform.position + offset;
        transform.position = new Vector3(
            Mathf.Clamp(target.x, minX + cam.orthographicSize, maxX - cam.orthographicSize),
            Mathf.Clamp(target.y, minY + cam.orthographicSize, maxY - cam.orthographicSize), target.z);
    }
    
    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        Vector3 target = player.transform.position + offset;
        float targetDistance = Vector2.Distance(target, transform.position);
        if(targetDistance >= maxDistanceRatio * cam.orthographicSize) {
            float speed = cameraSpeed;
            if(targetDistance >= 0.9f * cam.orthographicSize) {
                speed = speed * 2;
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(
            Mathf.Clamp(target.x, minX + cam.orthographicSize * cam.aspect, maxX - cam.orthographicSize * cam.aspect),
            Mathf.Clamp(target.y, minY + cam.orthographicSize, maxY - cam.orthographicSize), target.z), speed);
        }

        if (cam.orthographicSize <= targetSize - cameraSpeed) {
            cam.orthographicSize += cameraSpeed / 2.0f;
        } else if (cam.orthographicSize >= targetSize + cameraSpeed) {
            cam.orthographicSize -= cameraSpeed / 2.0f;
        }

    }
    
    public void SetSize(float size) {
        targetSize = size;
    }
}

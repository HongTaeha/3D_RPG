using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Player player;
    Vector3 oldpos;
    public float zoomSpeed = 50.0f;
    public float smoothRotate = 5.0f;
    Camera cam;
    Vector3 pos;
    float distance;
    void Start()
    {
        player = player.GetComponent<Player>();
        cam = GetComponent<Camera>();
        oldpos = Vector3.zero;
        pos = transform.position;
        distance = Vector3.Distance(pos, player.transform.position);
    }
    void Update()
    {

    }
    private void LateUpdate()
    {        
        Zoom();
        Rotate();
    }

    private void follow()
    {

        Vector3 deltapos= player.transform.position - oldpos;
        transform.position += deltapos;
        oldpos = player.transform.position;
    }
    private void Zoom()
    {
        float zoom_distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (zoom_distance != 0)
        {
            cam.fieldOfView += zoom_distance;
            distance = Vector3.Distance(pos, player.transform.position);
        }
    }

    private void Rotate()
    {
        float angle = Mathf.LerpAngle(
            transform.eulerAngles.y,
            player.transform.eulerAngles.y, smoothRotate * Time.deltaTime);
        Quaternion rot = Quaternion.Euler(0, angle, 0);

        transform.position = player.transform.position
            - (rot * Vector3.forward *distance)
            + (Vector3.up * pos.y);

        transform.LookAt(player.transform);

    }
}

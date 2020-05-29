using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_minimap : MonoBehaviour
{
    Camera cam;
    public GameObject player;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        pos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.x = player.transform.position.x;
        pos.z = player.transform.position.z;
        cam.transform.position = pos;

    }
}

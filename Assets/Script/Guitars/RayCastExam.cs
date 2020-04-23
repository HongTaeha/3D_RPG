using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastExam : MonoBehaviour
{
    Transform start;
    Transform end;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.yellow);
        Vector3 vDir = end.position - start.position;

        Debug.DrawRay(start.position, vDir.normalized * 10f, Color.yellow);
    }
}

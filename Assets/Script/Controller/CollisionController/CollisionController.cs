using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : Controller
{

    GameObject obj;
     void Start()
    {
        obj = GetComponent<GameObject>();    
    }

    private void Update()
    {
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Collision");
        if (collisionInfo.collider.CompareTag("ground"))
            print("No longer in contact with " + collisionInfo.transform.name);
    }
}

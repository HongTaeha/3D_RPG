using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.position = enemy.POS;
    }
}

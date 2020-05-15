using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Character enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Character>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.position = enemy.POS;
    }
}

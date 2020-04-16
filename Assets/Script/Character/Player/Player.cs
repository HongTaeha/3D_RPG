using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    [HideInInspector]
    public bool isJumping = false;
    void Start()
    {
        StrName = "Player";
        HP = 10;
        MP = 10;
        Range = 2;

        ani = GetComponent<Animator>();
        POS = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        mypos = transform.position;

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    

    public Character Attack_Target;

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

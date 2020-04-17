using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        StrName = this.name;
        HP = 10;
        MP = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

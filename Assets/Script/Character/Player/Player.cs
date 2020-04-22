using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    


    void Start()
    {
        StrName = "Player";
        ani = GetComponent<Animator>();
        HP = 10;
        MP = 10;
        Max_HP = 10;
        Max_MP = 10;
        Range = 2;
        attackSpeed = 2;
        attackCoolTime = 1;
        currentAttackCoolTime = 1;
        POS = transform.position;
        AttackDamage = 2;
    }

    // Update is called once per frame
    void Update()
    {
        mypos = transform.position;

        SetAttackSpeed(attackSpeed);


    }
}

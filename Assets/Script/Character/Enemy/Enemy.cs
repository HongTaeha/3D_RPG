using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    bool isDead=false;
    // Start is called before the first frame update
    void Start()
    {
        StrName = this.name;
        HP = 10;
        MP = 10;
        Max_HP = 10;
        Max_MP = 10;
        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }
    void Die()
    {
        if (HP <= 0 && isDead != true)
        {
            ani.SetTrigger("Die");
            isDead = true;
        }

    }
    void DieEvent()
    {
        Destroy(ani.gameObject);
    }
}

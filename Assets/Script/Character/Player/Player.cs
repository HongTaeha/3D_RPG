using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Status tmp;
    void Start()
    {
        status = new Status();
        Status_DB.instance.status_dic.TryGetValue("Player", out tmp);
        
        Get_Status(this.status, tmp);

        Debug.Log(tmp.StrName);
        

        ani = GetComponent<Animator>();
        
        attackCoolTime = 1;
        currentAttackCoolTime = 1;
        POS = transform.position;
        
        isDead= false;
    }

  

    // Update is called once per frame
    void Update()
    {
        mypos = transform.position;

        SetAttackSpeed(this.status.attackSpeed);
        Die();        
    }
}

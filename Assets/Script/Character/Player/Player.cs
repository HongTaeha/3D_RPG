using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    Status st = null;
    void Start()
    {       
        st = new Status();
        st.StrName = "Player";
        st.HP = 10;
        st.MP = 10;
        st.Max_HP = 10;
        st.Max_MP = 10;
        st.Range = 2;
        st.attackSpeed = 2;
        st.AttackDamage = 2;
        Status_DB.instance.status_dic.Add("Player", st);


        Status_DB.instance.status_dic.TryGetValue("Player",out status);

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

        //        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 15);
    }
}

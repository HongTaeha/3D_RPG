using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : Character
{
    Status tmp;
    void Start()
    {
        Navi = GetComponent<NavMeshAgent>();
        
        status = new Status();
        skillbook = new List<Skills>();      

        db = Resources.Load<Skills_DB>("Skills_DB");
        for(int i=0;i<db.skills.Count;i++)
        {
            addskill(db.skills[i]);
        }

        Status_DB.instance.status_dic.TryGetValue("Player", out tmp);        
        Get_Status(this.status, tmp);
        ani = GetComponent<Animator>();  
        POS = transform.position;

       

        isDead = false;
        SetAttackSpeed("Attack1", 1);

    }

  

    // Update is called once per frame
    void Update()
    {
        //mypos = transform.position;
        Die();        
    }

}

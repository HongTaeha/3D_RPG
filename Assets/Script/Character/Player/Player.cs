using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Status tmp;    
    
   
    void Start()
    {
        status = new Status();
        skillbook = new List<Skills>();
        var database = Resources.Load<Skills_DB>("Skills_DB");
        skillbook.Add(database.skills[0]);        
        Status_DB.instance.status_dic.TryGetValue("Player", out tmp);        
        Get_Status(this.status, tmp);
        Debug.Log(tmp.StrName);      
        ani = GetComponent<Animator>();  
        POS = transform.position;

        RuntimeAnimatorController ac = ani.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == "Attack1")
            {
                this.status.attackSpeed = ac.animationClips[i].length;
            }
        }

        isDead = false;
    }

  

    // Update is called once per frame
    void Update()
    {
        mypos = transform.position;
        SetAttackSpeed(this.status.attackSpeed,1);
        Die();        
    }

}

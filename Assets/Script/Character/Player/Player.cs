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
        ani.SetFloat("WalkSpeed",SetWalkSpeed("Walk"));
        Navi.speed = 3.0f;

    }


    public void Rotate(Character obj, Vector3 _pos, float speed)
    {
        Vector3 targetDir = _pos - obj.transform.position;
        if (Vector3.Dot(targetDir.normalized, obj.transform.forward).CompareTo(0.99f) >= 0)
            return;

        Vector3 newDir = Vector3.RotateTowards(obj.transform.forward, targetDir.normalized, Time.deltaTime * speed, 0);
        obj.transform.rotation = Quaternion.LookRotation(newDir);
    }

    // Update is called once per frame
    void Update()
    {
        //mypos = transform.position;
        Die();
        if (Vector3.Distance(this.POS, this.transform.position) < 1f)
        {
            this.POS = this.transform.position;
        }
        
    }

}

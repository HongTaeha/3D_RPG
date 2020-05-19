using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : Character
{
    Status tmp;
    public Character Attack_Target = null;
    public bool is_Automatic = false;    
    public Items_DB idb;
    void Start()
    {
        Inventory = new List<Items>();
        Equipment = new List<Item_Equip>();
        QuestItems = new List<Item_Quest>();
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
        
        idb = Resources.Load<Items_DB>("Items_DB");

        for (int i = 0; i < idb.item.Count; i++)
        {
            additem(idb.item[i]);
        }

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
    public void HitEvent()
    {
        if (this.Attack_Target)
        {
            Attack_Target.Take_Damage(this.status.AttackDamage);
        }
    }
  
}

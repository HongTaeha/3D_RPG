using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : Character
{
    public Vector3 Spawn_Point = Vector3.zero;
    public bool is_returning=false;
    

    public float SPAWNDISTANCE
    {
        get { return Vector3.Distance(this.transform.position, Spawn_Point); }
    }    
    Status tmp;
    void Start()
    {

        inven = new Inventory();       
        Navi = GetComponent<NavMeshAgent>();
        status = new Status();
        skillbook = new List<Solo_skill>();
        this.tag = "Enemy";
        Status_DB.instance.status_dic.TryGetValue("Enemy", out tmp);
        this.addskill(Skills_DB.instance.skills[0]);
        Get_Status(this.status,tmp);
        this.status.StrName = this.name;
        ani = GetComponent<Animator>();
        POS = transform.position;
        isDead = false;
        SetAttackSpeed("Stab Attack", 0.5f);
        ani.SetFloat("WalkSpeed", SetWalkSpeed("Run Forward In Place"));
        Navi.speed = 3.0f;
    }
   
    // Update is called once per frame
    void Update()
    {
        Die();
        if (Vector3.Distance(this.POS, this.transform.position) < 1)
        {
            this.POS = this.transform.position;
        }
        if(!is_returning)
            Recognition();    
        if(SPAWNDISTANCE>15.0f)
        {
            Return_Spawnpoint();
        }
        if (Vector3.Distance(this.transform.position, this.Spawn_Point) < 1 && this.is_returning)
            this.is_returning = false;
        if(this.transform.position!= this.POS)
        {
            this.Move(this, this.POS);
            this.Rotate(this, this.POS);
        }

    }
    void DieEvent()
    {
        
        //ObjectPooler.instance.AddRemoveObj(ani.gameObject);
        ObjectPooler.instance.ReleaseObj(ani.gameObject);
        //Destroy(ani.gameObject);
    }

  
    //스폰 지점에서 일정 반경 내로 랜덤 이동
    public void Random_spot()
    {
        Vector3 tmp = this.POS;
               
            float dx = Random.Range(-3f, 3f);
            float dz = Random.Range(-3f, 3f);
            tmp.x = this.Spawn_Point.x + dx;
            tmp.z = this.Spawn_Point.z + dz;
       
        this.POS = tmp;
    }

    //일정 거리 안의 플레이어 인식
    public void Recognition()
    {
        Collider[] cols = Physics.OverlapSphere(this.transform.position, 5);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].CompareTag("Player"))
            {
                this.target = cols[i].GetComponent<Character>();
                this.POS = this.target.transform.position;
                break;
            }
        }
    }

    //플레이어가 죽거나 일정 반경 밖으로 나가면 제자리로 돌아감
    
    public void Return_Spawnpoint()
    {
        this.is_returning = true;
        this.target = null;
        this.POS = this.Spawn_Point;        
        ani.SetInteger("iAniIndex", 1);

    }
    public void HitEvent()
    {
        if (this.target)
        {
            target.Take_Damage(this.status.AttackDamage);
        }
    }

}

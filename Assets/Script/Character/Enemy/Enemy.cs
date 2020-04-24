using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    Vector3 Spawn_Point = Vector3.zero;
    bool is_returning=false;
    float SPAWNDISTANCE
    {
        get { return Vector3.Distance(this.transform.position, Spawn_Point); }
    }

    Status tmp;
    void Start()
    {        
        status = new Status();
        Status_DB.instance.status_dic.TryGetValue("Enemy", out tmp);
        Get_Status(this.status,tmp);
        this.status.StrName = this.name;
        ani = GetComponent<Animator>();       

        attackCoolTime = 1;
        currentAttackCoolTime = 1;

        POS = transform.position;
        isDead = false;
        Spawn_Point = transform.position;
        Is_Battle = true;

    }

    // Update is called once per frame
    void Update()
    {
        Die();
        SetAttackSpeed(this.status.attackSpeed);


        if (SPAWNDISTANCE > 10)
        {
            Return_Spawnpoint();
        }
        else
        {
            if (this.target == null)
            {
                if (Is_Battle == true)
                    //Recognition("Player");
                Move_Random();
            }
            else
            {
                this.Is_Battle = true;
                if (target.status.HP <= 0)
                    this.Is_Battle = false;
                Move(this, target.transform.position);

            }
        }

        


    }
    

    void DieEvent()
    {
        Destroy(ani.gameObject);
    }

    //적이 해야할 행동

    //스폰 지점에서 일정 반경 내로 랜덤 이동
    public void Move_Random()
    {
        Move(this, this.POS);


    }

    //일정 거리 안의 플레이어 인식
    public void Recognition(string tag)
    {
        Collider[] cols = Physics.OverlapSphere(this.transform.position, 15);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].CompareTag(tag))
                this.target = cols[i].GetComponent<Character>();
        }
    }

    //플레이어가 죽거나 일정 반경 밖으로 나가면 제자리로 돌아감


    public void Return_Spawnpoint()
    {
        is_returning = true;
        this.target = null;
        this.Is_Battle = false;
        this.POS = Spawn_Point;

        if (this.transform.position!=Spawn_Point)
        {
            Move(this, this.Spawn_Point);
        }
        else
        {
            is_returning = false;            
            this.Is_Battle = true;


        }
        
    }    


}

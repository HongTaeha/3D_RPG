using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Vector3 Spawn_Point = Vector3.zero;
    bool is_returning=false;
    public float SPAWNDISTANCE
    {
        get { return Vector3.Distance(this.transform.position, Spawn_Point); }
    }

    Status tmp;

    private void Awake()
    {
        Spawn_Point = transform.position;
    }
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
        Is_Battle = true;
    }
   
    // Update is called once per frame
    void Update()
    {
        Die();
        SetAttackSpeed(this.status.attackSpeed);
        //Recognition("Player");
       

        
    }
    private void LateUpdate()
    {
        if (is_Move)
        {
            this.Move(this, this.POS);
            //this.Rotate(this, this.POS);
            this.is_Move = false;
        }
    }


    void DieEvent()
    {
        Destroy(ani.gameObject);
    }

  
    //스폰 지점에서 일정 반경 내로 랜덤 이동
    public void Random_spot()
    {
        Vector3 tmp = this.POS;
        int nR = Random.Range(0, 10);
        if (nR == 0 || nR == 4 || nR == 9)
        {            
            float dx = Random.Range(-4f, 4f);
            float dz = Random.Range(-4f, 4f);
            tmp.x = this.Spawn_Point.x + dx;
            tmp.z = this.Spawn_Point.z + dz;
        }
        //Debug.Log(this.name);
        this.POS = tmp;
        //return tmp;        
    }

    //일정 거리 안의 플레이어 인식
    public void Recognition(string tag)
    {
        Collider[] cols = Physics.OverlapSphere(this.transform.position, 5);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].CompareTag(tag))
            {
                this.target = cols[i].GetComponent<Character>();
                this.POS = this.target.POS;
                break;
            }
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

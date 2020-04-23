using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    Vector3 Spawn_Point = Vector3.zero;
    Status st = null;
    void Start()
    {
        st = new Status();
        st.StrName = this.name;
        st.HP = 10;
        st.MP = 10;
        st.Max_HP = 10;
        st.Max_MP = 10;
        st.Range = 2;
        st.attackSpeed = 2;
        st.AttackDamage = 2;
        Status_DB.instance.status_dic.Add(this.name, st);


        Status_DB.instance.status_dic.TryGetValue(this.name, out this.status);

        ani = GetComponent<Animator>();       
        attackCoolTime = 1;
        currentAttackCoolTime = 1;
        POS = transform.position;
        isDead = false;
        Spawn_Point = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        SetAttackSpeed(this.status.attackSpeed);
    }

    void DieEvent()
    {
        Destroy(ani.gameObject);
    }

    //적이 해야할 행동

    //스폰 지점에서 일정 반경 내로 랜덤 이동
    public void Move_Random()
    {

    }

    //일정 거리 안의 플레이어 인식
    public void Recognition()
    {

    }

    //플레이어가 죽거나 일정 반경 밖으로 나가면 제자리로 돌아감


    public void Return_Spawnpoint()
    {

    }






}

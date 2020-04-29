using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    //목표 대상 구현
    public Character Attack_Target=null;
    public Character target = null;
    public Vector3 targetpos //디버그용
    {
        get
        {
            if (target != null)
                return target.transform.position;
            else
                return transform.position;
        }
    }
    public Vector3 mypos; 
    

    //애니메이션
    public Animator ani;
    float speed = 3.0f;
    private Vector3 pos = Vector3.zero;
    public Vector3 POS
    {        
            get { return pos; }
            set { pos= value; }
    }
    public bool Is_Battle = false;
    public bool is_Move = false;



    //케릭터 스텟    
    public Status status;
    public float attackCoolTime ;
    public float currentAttackCoolTime ;

    //케릭터 상태
    public bool isDead = false;

    public void Take_Damage(float dmg)
    {
        status.HP -= dmg;
    }
    public void Die()
    {
        if (status.HP <= 0 && isDead != true)
        {
            ani.SetTrigger("Die");
            isDead = true;
        }

    }
    void Start()
    {
     }


    void Update()
    {
    }


    public void Get_Status(Status st1, Status st)
    {

        st1.StrName= st.StrName;
        st1.Range=st.Range;
        st1.Armor = st.Armor;
        st1.Max_HP=st.Max_HP;
        st1.Max_HP=st.Max_MP;
        st1.HP=st.HP;
        st1.MP=st.MP;
        st1.AttackDamage = st.AttackDamage;
        st1.attackSpeed = st.attackSpeed;
    }

    public float TargetDIstance(Character obj,Character target)
    {

        return Vector3.Distance(obj.transform.position, target.transform.position);
        
    }

    public void Move(Character obj, Vector3 _pos)
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, _pos, Time.deltaTime * speed);
    }

    public void Rotate(Character obj, Vector3 _pos)
    {
        Vector3 targetDir = _pos - obj.transform.position;
        if (Vector3.Dot(targetDir.normalized, obj.transform.forward).CompareTo(0.99f) >= 0)
            return;

        Vector3 newDir = Vector3.RotateTowards(obj.transform.forward, targetDir.normalized, Time.deltaTime * 10, 0);
        obj.transform.rotation = Quaternion.LookRotation(newDir);
    }

    public void SetAttackSpeed(float _attackSpeed)
    {
        this.status.attackSpeed = _attackSpeed;
        attackCoolTime = 1f / status.attackSpeed;
        currentAttackCoolTime = attackCoolTime;
        ani.SetFloat("AttackSpeed", status.attackSpeed);
        

    }
    
    public void StartAttack()
    {
        StartCoroutine("EnumAttack");
    }
    public void EndAttack()
    {
        StopCoroutine("EnumAttack");
    }
    private IEnumerator EnumAttack()
    {
        while (true)
        {
            if (currentAttackCoolTime >= attackCoolTime)
            {
                currentAttackCoolTime = 0;
                Attack();
            }
            
            currentAttackCoolTime += Time.deltaTime;
            yield return null;         
        }

    }
    private void Attack()
    {
        ani.SetInteger("iAniIndex", 2);
    }
    public void HitEvent()
    {
        if(this.Attack_Target)
        Attack_Target.Take_Damage(this.status.AttackDamage);
    }

}

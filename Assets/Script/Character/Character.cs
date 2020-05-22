using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{

    public NavMeshAgent Navi;
    //목표 대상 구현
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
    public Sprite icon;

    //애니메이션
    public Animator ani;
    float speed = 3.0f;
    private Vector3 pos = Vector3.zero;
    public Vector3 POS
    {
        get { return pos; }
        set { pos = value; }
    }


    //케릭터 스텟    
    public Status status;
    float attackCoolTime;
    float currentAttackCoolTime;

    public List<Solo_skill> skillbook;
    public List<Items> Inventory;
    public List<Item_Equip> Equipment;
    public List<Item_Quest> QuestItems;

    //케릭터 스킬
    public List<Buff> buff;
    public List<float> buffTimers;
    public List<Debuff> dbuff;
    public List<float> dbuffTimers;

    //케릭터 상태
    public bool isDead = false;
    public void Take_Damage(float dmg)
    {
        float total_dmg;
        total_dmg = dmg - this.status.Armor;
        if (dmg < 0)
            dmg = 0;
        this.status.HP -= total_dmg;
    }
    public void Take_Heal(float heal)
    {

        this.status.HP += heal;
        if (this.status.HP > this.status.Max_HP)
            this.status.HP = this.status.Max_HP;

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
    void Ani_speed(string str)
    {

    }
    public List<Character> Recognition(string tag, float range)
    {
        Collider[] cols = Physics.OverlapSphere(this.transform.position, range);
        List<Character> ch = new List<Character>();
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].CompareTag(tag))
            {
                ch.Add(cols[i].GetComponent<Character>());
            }
        }
        return ch;
    }
    public void addBuff(Buff b, float Time)
    {
        buff.Add(b);
        buffTimers.Add(Time);
    }
    public void Buff_Timer()
    {
        if (buffTimers.Count > 0)
        {
            for (int i = 0; i < buffTimers.Count; i++)
            {
                buffTimers[i] -= Time.deltaTime;
                if (buffTimers[i] <= 0)
                {
                    //Buff b = buff[i];
                    buff.RemoveAt(i);
                    buffTimers.RemoveAt(i);

                }
            }
        }
    }
    public void Get_Status(Status st1, Status st)
    {

        st1.StrName = st.StrName;
        st1.Range = st.Range;
        st1.Armor = st.Armor;
        st1.Max_HP = st.Max_HP;
        st1.Max_MP = st.Max_MP;
        st1.HP = st.HP;
        st1.MP = st.MP;
        st1.AttackDamage = st.AttackDamage;
        st1.attackSpeed = st.attackSpeed;
    }
    public float TargetDIstance(Character obj, Character target)
    {
        return Vector3.Distance(obj.transform.position, target.transform.position);
    }
    public void Move(Character obj, Vector3 _pos)
    {
        //obj.transform.position = Vector3.MoveTowards(obj.transform.position, _pos, Time.deltaTime * speed);        
        obj.Navi.SetDestination(_pos);
    }
    public void Rotate(Character obj, Vector3 _pos)
    {
        Vector3 targetDir = _pos - obj.transform.position;
        if (Vector3.Dot(targetDir.normalized, obj.transform.forward).CompareTo(0.99f) >= 0)
            return;

        Vector3 newDir = Vector3.RotateTowards(obj.transform.forward, targetDir.normalized, Time.deltaTime * 10, 0);
        obj.transform.rotation = Quaternion.LookRotation(newDir);
    }
    public void SetAttackSpeed(string str, float _attackCooltime)
    {
        RuntimeAnimatorController ac = this.ani.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == str)
            {
                this.status.attackSpeed = ac.animationClips[i].length;
                break;
            }
        }

        this.status.attackSpeed = this.status.attackSpeed * _attackCooltime;
        attackCoolTime = 1f / status.attackSpeed;
        currentAttackCoolTime = attackCoolTime;

        ani.SetFloat("AttackSpeed", status.attackSpeed);

    }
    public float SetWalkSpeed(string str)
    {
        RuntimeAnimatorController ac = this.ani.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == str)
            {
                return ac.animationClips[i].length;

            }
        }
        return 0;
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
                ani.SetInteger("iAniIndex", 2);
                currentAttackCoolTime = 0;
            }
            else
                currentAttackCoolTime += Time.deltaTime;
            yield return null;
        }
    }
    public void Use_Skill(int num)
    {
        if (skillbook[num].is_Active && skillbook[num].is_Available)
        {
            skillbook[num].Use(this);
        }
    }
    public void addskill(Skills skill)
    {
        Solo_skill tmp = new Solo_skill();
        skill.Copy(tmp);
        skillbook.Add(tmp);
    }
    public void additem(Item_Consum item)
    {
        Item_Consum tmp = new Item_Consum();
        item.Copy(tmp);
        if (Inventory.Exists(x => x.Item_No == tmp.Item_No))
        {
            Inventory[Inventory.FindIndex(x => x.Item_No == tmp.Item_No)].Amount += tmp.Amount;
            
        }
        Inventory.Add(tmp);
    }
    public void additem(Item_Equip item)
    {
        Item_Equip tmp = new Item_Equip();
        item.Copy(tmp);
        Inventory.Add(tmp);
    }
    public void additem(Item_Quest item)
    {
        Item_Quest tmp = new Item_Quest();
        item.Copy(tmp);
        QuestItems.Add(tmp);
    }

}

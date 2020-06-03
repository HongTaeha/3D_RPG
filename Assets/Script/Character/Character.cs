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

    public List<Solo_skill> skillbook;
    public Inventory inven;

   
    void Start()
    {
    }


    void Update()
    {
    }
    public class Inventory
    {
        public class Item
        {
            public int num;
            public Item_Consume con;
            public Item_Equip equip;            
        }
        public List<Item> Inven = new List<Item>();
        List<Item_Quest> QuestItems = new List<Item_Quest>();
        public int Count
        {
            get { return Inven.Count; }
        }
        public void sortInven()
        {
            Inven.Sort((x, y) => x.num.CompareTo(y.num));
            int i = 0;
            foreach(Item t in Inven)
            {
                t.num = i;
                i++;
            }
        }        
        public void Additem<T>(T t) where T : Items,new()
        {
            switch(t.Tag)
            {
                case "Consume":
                    Item tem = new Item();
                    tem.con = new Item_Consume();
                    tem.con.Copy(t);
                    tem.num = Inven.Count ;
                    Inven.Add(tem);
                    break;
                case "Equip":
                    Item tem1 = new Item();
                    tem1.equip = new Item_Equip();
                    tem1.equip.Copy(t);
                    tem1.num = Inven.Count;
                    Inven.Add(tem1);
                    break;
                case "Quest":
                    Item_Quest tmp3 = new Item_Quest();
                    tmp3.Copy(t);
                    QuestItems.Add(tmp3);
                    break;
            }
            sortInven();
        }
        public void Removeitem<T>(T t) where T : Items
        {
            switch(t.Tag)
            {
                case "Consume":
                    foreach (Item tem in Inven)
                    {
                        if (tem.con == t)
                        {
                            Inven.Remove(tem);
                            break;
                        }
                    }
                    break;
                case "Equip":
                    foreach (Item tem in Inven)
                    {
                        if (tem.equip == t)
                        {
                            Inven.Remove(tem);
                            break;
                        }
                    }
                    break;
                case "Quest":
                    Item_Quest te = new Item_Quest();
                    te.Copy(t);
                    QuestItems.Remove(te);
                    break;
            }
        }       
        public bool Is_consume(int num1)
        {
            foreach(Item t in Inven)
            {
                if (t.num == num1&&t.con!=null)
                    return true;
            }
            return false;
        }
        public bool Exists(int num1)
        {
            if (Inven.Exists(x => x.num == num1))
                return true;
            else
                return false;
        }
        public int Exists<T>(T t)where T:Items
        {
            switch(t.Tag)
            {
                case "Consume":
                    if (Inven.Exists(x => x.con == t))
                    {
                        foreach(Item tem in Inven)
                        {
                            if (tem.con == t)
                            {
                                return tem.num;
                            }
                        }
                    }
                        break;
                case "Equip":
                    if (Inven.Exists(x => x.equip == t))
                    {
                        foreach (Item tem in Inven)
                        {
                            if (tem.equip == t)
                            {
                                return tem.num;
                            }
                        }
                    }

                    break;
                case "Quest":
                    if(QuestItems.Exists(x=>x==t))
                    {
                        int i = 0;
                        foreach(Item_Quest te in QuestItems)
                        {
                            if(te==t)
                            {
                                return i;
                            }
                            i++;
                        }
                    }
                    break;
                default:
                    return 0;
            }
            return 0;
        }
        public Item Findbynum(int num)
        {
            
            foreach(Item tem in Inven)
            {
                if(tem.num==num)
                {
                    return tem;      
                }
            }
            return null;
        }
        public void Swapnum(int num, int num1)
        {
            Item tmp1 = Findbynum(num);
            Item tmp2 = Findbynum(num1);

            tmp1.num = num1;
            tmp2.num = num;
        }
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
        if (skillbook[num] != null)
        {
            if (skillbook[num].is_Active && skillbook[num].is_Available)
            {
                skillbook[num].Use(this);
            }
        }
        else
        {
            Debug.Log("배정된 스킬이 없습니다.");
        }
    }
    public void addskill(Skills skill)
    {
        Solo_skill tmp = new Solo_skill();
        skill.Copy(tmp);
        skillbook.Add(tmp);
    }
   

}

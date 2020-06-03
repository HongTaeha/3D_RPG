using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Player : Character
{


    //아이템 구현
    float Item_cooldown = 0;
    bool Item_Available = true;


    Status tmp;
    public Character Attack_Target = null;
    public bool is_Automatic = false;
    private void Awake()
    {
        inven = new Inventory();
        Navi = GetComponent<NavMeshAgent>();
        status = new Status();
        skillbook = new List<Solo_skill>();
        Status_DB.instance.status_dic.TryGetValue("Player", out tmp);
        addskill((Solo_skill)Skills_DB.instance.skills[0]);
    }
    void Start()
    {

        inven.Additem<Item_Consume>(Items_DB.instance.c[0]);
        inven.Additem<Item_Consume>(Items_DB.instance.c[1]);
        inven.Additem<Item_Consume>(Items_DB.instance.c[2]);
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
    public void HitEvent()
    {
        if (this.Attack_Target&&this.TargetDIstance(this,this.Attack_Target)<this.status.Range)
        {
            Attack_Target.Take_Damage(this.status.AttackDamage);
        }
    }

    public void Use_Item(int num)
    {        
        if (Item_Available)
        {
            if (inven.Exists(num)&&inven.Is_consume(num))
            {
                inven.Inven[num].con.Use(this);
                if (inven.Is_consume(num)) //소비템일때
                {
                    Item_cooldown = inven.Inven[num].con.CoolTime;
                    inven.Inven[num].con.Amount -= 1;
                    if (inven.Inven[num].con.Amount < 1)
                    {
                        inven.Removeitem<Item_Consume>(inven.Inven[num].con);
                    }
                    Item_Available = false;
                    cooldown(this);
                }
                else //장비템일때
                {

                }
            }
        }
    }
    public void cooldown(MonoBehaviour parentMonoBehaviour)
    {
        parentMonoBehaviour.StartCoroutine(CooldownTimeCoroutine());
    }
    IEnumerator CooldownTimeCoroutine()
    {
        float startTime = Time.deltaTime;
        float cooltime = Item_cooldown;
        while (cooltime > 0)
        {
            Item_cooldown -= Time.deltaTime;            
            if (Item_cooldown <= 0)
            {
                Item_Available = true;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
}

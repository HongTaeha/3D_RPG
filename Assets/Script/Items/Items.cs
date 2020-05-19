using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Items :ScriptableObject
{
    public string item_name;
    public int Item_No;
    public bool breakable = true;
    public int price;
    public string item_info;
    public string tag;
    public float CoolTime = 10;   

    public virtual void update()
    {

    }
    public void Awake()
    {
        this.update();
    }
    public virtual void Use(Character user)
    {

    }


}

[CreateAssetMenu(fileName = "Item_Consum", menuName = "Item_Consum")]
public class Item_Consum : Items
{
    public Buff buff;
    public bool is_Available=true;
    public int value;
    public bool is_Damage = false;
    public override void Use(Character user)
    {

        Debug.Log(user.name+"가"+this.name+" 아이템 사용");
        if (buff!=null)
        {
            user.buff.Add(buff);
            user.buffTimers.Add(buff.duration);
        }
        if (is_Damage)
            user.target.Take_Damage(value);
        else
            user.Take_Heal(value);

        this.cooldown(user);
    }
    public override void update()
    {
        this.price = 0;
        this.CoolTime = 60;
        this.tag = "Consume";
        this.value = 5;
    }
    public void cooldown(MonoBehaviour parentMonoBehaviour)
    {
        parentMonoBehaviour.StartCoroutine(CooldownTimeCoroutine());
    }
    IEnumerator CooldownTimeCoroutine()
    {
        float startTime = Time.deltaTime;
        float cooltime = CoolTime;
        while (cooltime > 0)
        {
            cooltime -= Time.deltaTime;
            if (cooltime <= 0)
            {
                is_Available = true;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }

}
public class Item_Equip : Items
{
    public Status status;
    public override void update()
    {
        this.tag = "Equip";
    }
    public override void Use(Character user)
    {
        user.Equipment.Add(this);
    }

}
public class Item_Quest : Items
{
    public override void update()
    {
        this.tag = "Quest";
        this.breakable = false;
    }

}

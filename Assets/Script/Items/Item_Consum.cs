using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item_Consum : Items
{
    public int value;
    public bool is_Damage = false;

    public void Copy(Item_Consum other)
    {
        other.value = value;
        other.is_Damage = is_Damage;
        other.item_name = item_name;
        other.Item_No = Item_No;
        other.breakable = breakable;
        other.price = price;
        other.item_info = item_info;
        other.tag = tag;
        other.CoolTime = CoolTime;
        other.amount = amount;
    }
    public override void Use(Character user)
    {

        Debug.Log(user.name + "가" + this.item_name + " 아이템 사용");       
        if (is_Damage)
            user.target.Take_Damage(value);
        else
            user.Take_Heal(value);
    }
    public override void update()
    {
        this.tag = "Consume";
    }
}

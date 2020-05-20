using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public  class Items
{
    public string item_name;
    public int Item_No;
    public bool breakable = true;
    public int price;
    public string item_info;
    public string tag;
    public float CoolTime = 10;
    public int amount = 1;

    public void Copy(Items other)
    {
        other.item_name = item_name;
        other.Item_No = Item_No;
        other.breakable = breakable;
        other.price = price;
        other.item_info = item_info;
        other.tag = tag;
        other.CoolTime = CoolTime;
        other.amount = amount;
    }

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
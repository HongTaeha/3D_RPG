using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
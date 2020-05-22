using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item_Consum : Items
{
    public int Value=5;
    public bool is_Damage = false;

    public void Copy(Item_Consum other)
    {
        Copy((Items)other);
        other.Value = Value;
        other.is_Damage = is_Damage;
        other.Tag = "Consume";
    }
    public override IEnumerator Use_Item(Character user)
    {
        
           
                user.Take_Heal(Value);
        yield return null;
    }
}
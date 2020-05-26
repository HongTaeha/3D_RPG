using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item_Consume : Items
{
    public int Value=5;
    public bool is_Damage = false;
    public override void Awake()
    {
        is_Available = true;
        Sprite[] sprites = Resources.LoadAll<Sprite>("Icons/Potion");
        int num = Random.Range(0, sprites.Length);
        icon = sprites[num];
    }
    public void Copy(Item_Consume other)
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
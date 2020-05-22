using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Equip : Items
{
    public Status status;
    public override IEnumerator Use_Item(Character user)
    {
        yield return null;
    }

}
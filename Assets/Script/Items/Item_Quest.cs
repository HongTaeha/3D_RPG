using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Quest : Items
{
    public override void update()
    {
        this.tag = "Quest";
        this.breakable = false;
    }

}

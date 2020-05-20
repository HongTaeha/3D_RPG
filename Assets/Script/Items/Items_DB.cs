using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Items_DB :SingleTon<Items_DB>
{
    public List<Items> item = new List<Items>();
    public void Update_DB()
    {


    }
    public void Print()
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i] != null)
                Debug.Log(item[i].item_name);
        }
    }
    public void wakeup()
    {
        for (int i = 0; i < item.Count; i++)
        {
            item[i].Awake();
        }
    }
    public void Clear()
    {
        item = new List<Items>();
    }
}


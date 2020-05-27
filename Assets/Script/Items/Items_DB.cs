using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Items_DB :SingleTon<Items_DB>
{
    public List<Item_Consume> c = new List<Item_Consume>();
    public List<Item_Equip> e = new List<Item_Equip>();
    public List<Item_Quest> q = new List<Item_Quest>();
    
    public void Update_DB()
    {


    }
    public void Print()
    {
        foreach (Item_Consume a in c)
        {
            Debug.Log(a.Item_name);
        }
        foreach (Item_Equip a in e)
        {
            Debug.Log(a.Item_name);
        }
        foreach (Item_Quest a in q)
        {
            Debug.Log(a.Item_name);
        }
    }
    public void wakeup()
    {
      foreach( Item_Consume a in c)
        {
            a.Awake();
        }
        foreach (Item_Equip a in e)
        {
            a.Awake();
        }
        foreach (Item_Quest a in q)
        {
            a.Awake();
        }
    }
    public void Clear()
    {
        
    }
}


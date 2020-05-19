using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class Items_DB : ScriptableObject
{
    string[] fName;
    Object[] fObj;
    public List<Items> item = new List<Items>();
    public void Update_DB()
    {
        Items[] instances = Resources.LoadAll<Items>("Items");
        for (int i = 0; i < instances.Length; i++)
        {
            item.Add(instances[i]);
        }

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


public class ItemMenu
{
    [MenuItem("Assets/Create/Item Database")]
    public static void CreateSkillDatabaseAsset()
    {
        ScriptableObjectUtility.CreateAsset<Items_DB>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class LoadItems : MonoBehaviour
{
    public string FileName;
    void Awake()
    {
        TextAsset txtAsset = Resources.Load<TextAsset>(FileName);
        JSONNode root = JSON.Parse(txtAsset.text);
        JSONNode N1 = root[0];
        for (int i = 0; i < root.Count; i++)
        {
            JSONNode N = root[i];
            string str = N["Tag"];                     
            switch (str)
            {
                case "Consume":
                    Item_Consume tmp = new Item_Consume();
                    tmp = Add<Item_Consume>(str, N);
                    Items_DB.instance.c.Add(tmp);
                    break;
                case "Equip":
                    Item_Equip tmp1 = new Item_Equip();
                    tmp1 = Add<Item_Equip>(str, N);
                    Items_DB.instance.e.Add(tmp1);
                    break;
                case "Quest":
                    Item_Quest tmp2 = new Item_Quest();
                    tmp2 = Add<Item_Quest>(str, N);
                    Items_DB.instance.q.Add(tmp2);
                    break;
            }

        }
        Items_DB.instance.wakeup();
    }
    T Add<T>(string str, JSONNode N) where T: Items, new()
    {
        T tmp = new T();
        tmp.Item_name = N["Item_name"];
        tmp.Item_No = N["Item_No"];
        tmp.is_Breakable = N["is_Breakable"];
        tmp.Price = N["Price"];
        tmp.Item_info = N["Item_info"];
        tmp.Tag = N["Tag"];
        tmp.CoolTime = N["CoolTime"];
        tmp.Amount = N["Amount"];
        tmp.Value = N["Value"];
        tmp.is_Damage = N["is_Damage"];
        return tmp;
    }

}

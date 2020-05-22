using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class LoadItems : MonoBehaviour
{
    public string FileName;
    void Awake()
    {
        Skills_DB.instance.wakeup();
        TextAsset txtAsset = Resources.Load<TextAsset>(FileName);
        JSONNode root = JSON.Parse(txtAsset.text);
        JSONNode N1 = root[0];
        for (int i = 0; i < root.Count; i++)
        {
            Item_Consum tmp = new Item_Consum();
            JSONNode N = root[i];
            tmp.Item_name = N["Item_name"];
            tmp.Item_No = N["Item_No"];
            tmp.is_Breakable = N["is_Breakable"];
            tmp.Price = N["Price"];
            tmp.Item_info = N["Item_info"];
            tmp.Tag = N["Tag"];
            tmp.CoolTime = N["CoolTime"];
            tmp.Amount = N["Amount"];
            Items_DB.instance.item.Add(tmp);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class JSON_Parsor : MonoBehaviour
{
    private void Awake()
    {
        TextAsset txtAsset = Resources.Load<TextAsset>("Status_JSON");
        JSONNode root = JSON.Parse(txtAsset.text);
        JSONNode N1 = root[0];
        
        
        for(int i=0;i<root.Count;i++)
        {
            Status tmp = new Status();
            JSONNode N = root[i];
            tmp.StrName = N["ID"];
            tmp.Armor = N["Armor"];
            tmp.Max_HP = N["Max_HP"];
            tmp.Max_MP = N["Max_MP"];
            tmp.HP = N["HP"];
            tmp.MP = N["MP"];
            tmp.Range = N["Range"];
            tmp.attackSpeed = N["AttackSpeed"];
            tmp.AttackDamage = N["AttackDamage"];
            Status_DB.instance.status_dic.Add(tmp.StrName, tmp);
            
        }
        

    }



}

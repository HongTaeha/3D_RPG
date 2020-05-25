using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class LoadSkills : MonoBehaviour
{

    public string FileName;
    void Awake()
    {
        TextAsset txtAsset = Resources.Load<TextAsset>(FileName);
        JSONNode root = JSON.Parse(txtAsset.text);
        JSONNode N1 = root[0];
        for (int i = 0; i < root.Count; i++)
        {
            Solo_skill tmp = new Solo_skill();
            JSONNode N = root[i];
            tmp.skillName = N["skillName"];
            tmp.CoolTime = N["CoolTime"];
            tmp.mpCost = N["mpCost"];
            tmp.SpellID = N["SpellID"];
            tmp.Animation_ID = N["Animation_ID"];
            tmp.value = N["value"];
            tmp.is_Available = N["is_Available"];
            tmp.is_Damage = N["is_Damage"];
            tmp.is_Active = N["is_Active"];            
            Skills_DB.instance.skills.Add(tmp);

        }
        Skills_DB.instance.wakeup();
    }
    private void Start()
    {

    }
    private void Update()
    {
        
    }

    private void OnDestroy()
    {
    }
}
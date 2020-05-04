using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Skills_DB : ScriptableObject
{
    public List<Skills> skills = new List<Skills>();   
    public void Update_DB()
    {            
        Skills[] instances = Resources.FindObjectsOfTypeAll<Skills>();
        for(int i=0; i<instances.Length;i++)
        {
            skills.Add(instances[i]);
        }
    }
    public void Print()
    {
        for(int i=0;i<skills.Count;i++)
        {
            if (skills[i] != null)
                Debug.Log(skills[i].skillName);
        }
    }

    public void Clear()
    {
        skills = new List<Skills>();
    }

}



public class SkillMenu
{
    [MenuItem("Assets/Create/Skill Database")]
    public static void CreateSkillDatabaseAsset()
    {
        ScriptableObjectUtility.CreateAsset<Skills_DB>();
    }
}

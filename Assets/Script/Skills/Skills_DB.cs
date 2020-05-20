using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class Skills_DB : SingleTon<Skills_DB>
{
    public List<Skills> skills = new List<Skills>();    
    public void Update_DB()
    {
        
        
    }
    public void Print()
    {
        for(int i=0;i<skills.Count;i++)
        {
            if (skills[i] != null)
                Debug.Log(skills[i].skillName);
        }
    }
    public void wakeup()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            skills[i].Awake();
        }
    }
    public void Clear()
    {
        skills = new List<Skills>();
    }

}


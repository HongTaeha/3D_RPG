using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Skills_DB :SingleTon<Skills>
{ 
    public Dictionary<int, Skills> skills = new Dictionary<int, Skills>();
    public void Awake()
    {
        for (int i = 0; i < skills.Count; i++)
        {
           
        }
    }
    public void Update()
    {
        foreach (KeyValuePair<int, Skills> items in skills)
        {
            skills[items.Key].Update();
        }
    }
        
}



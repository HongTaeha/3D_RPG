using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills 
{
    public string skillName = string.Empty; 
    public float mpCost = 0;
    public Character User = null;
    public Character Target = null;
    public bool isActive = false;
    
    public void Update()
    {
        if (!isActive)
        {
            
        }
    }
    

    public virtual IEnumerator Use()
    { // Coroutine so it can do stuff over time.
        isActive = true;
        yield return null;
        // Do stuff based on the settings above.
        isActive = false;
    }
    
}


public class Skill_1 : Skills
{
    public override IEnumerator Use()
    {
        yield return null;
    }
}


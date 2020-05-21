using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill_Range_", menuName = "Skill_Range")]
public class RangeSkill : Skills
{
    public override IEnumerator Use_Skill(Character user, Character target)
    {
        yield return null;
    }
}


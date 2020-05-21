using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
skill 종류
딜스킬
힐스킬
버프스킬
디버프 스킬

단일 대상
대상지정

다수 대상
버프형

범위 지정형

플레이어 전방형
*/

public class Solo_skill : Skills
{
    /*
    public override void Use(Character user, Character target)
    {


        Debug.Log(user.name + "가" + this.skillName + " 스킬 사용");
        if (!is_Active)
        {
            user.buff.Add(buff);
        }
        else
        if (is_Damage)
        {
            if (!user.CompareTag(target.gameObject.tag))
            {
                target.Take_Damage(value);
                user.ani.SetInteger("iAniIndex", Animation_ID);
            }
        }
        else
        {
            if (user.CompareTag(target.gameObject.tag))
            {
                target.Take_Heal(value);
                user.ani.SetInteger("iAniIndex", Animation_ID);
            }
        }
        is_Available = false;
        this.cooldown(user);
    }*/
    public override IEnumerator Use_Skill(Character user, Character target)
    {
        if (is_Damage)
        {
            if (!user.CompareTag(target.gameObject.tag))
            {
                target.Take_Damage(value);
                user.ani.SetInteger("iAniIndex", Animation_ID);
            }
        }
        else
        {
            if (user.CompareTag(target.gameObject.tag))
            {
                target.Take_Heal(value);
                user.ani.SetInteger("iAniIndex", Animation_ID);
            }
        }
        yield return null;
    }
}

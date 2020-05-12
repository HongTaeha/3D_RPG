using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Skills :ScriptableObject
{

    public string skillName = string.Empty;
    public float CoolDown=10;
    public float mpCost = 0;
    public float SpellID;
    public Sprite Icon;
    public int Animation_ID=5;
    public float value=5;
    public bool is_Available=true;
    public bool is_Damage = true;
    public bool is_Active = true;
    public Buff buff;

    public virtual void Use(Character user, Character target)
    {
    }

    public void Awake()
    {
        is_Available = true;
    }

    public void cooldown(MonoBehaviour parentMonoBehaviour)
    {
        parentMonoBehaviour.StartCoroutine(CooldownTimeCoroutine());        
    }   
    IEnumerator CooldownTimeCoroutine()
    {
        float startTime = Time.deltaTime;           
        float cooltime = CoolDown;
        while (cooltime > 0)
        {
            cooltime -= Time.deltaTime;
            if (cooltime <= 0)
            {
                is_Available = true;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
}

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

[CreateAssetMenu(fileName = "Skill_Solo_", menuName = "Skill_Solo")]
public class Solo_skill : Skills
{
   
    public override void Use(Character user, Character target)
    {

       
        if (!is_Active) {
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
            if(user.CompareTag(target.gameObject.tag))
            {
                target.Take_Heal(value);
                user.ani.SetInteger("iAniIndex", Animation_ID);
            }
        }
        is_Available = false;
    }
}

[CreateAssetMenu(fileName = "Skill_Range_", menuName = "Skill_Range")]
public class RangeSkill : Skills
{
    public override void Use(Character target, Character user)
    {
    }
}



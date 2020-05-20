using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Skills
{

    public string skillName = string.Empty;
    public float CoolTime = 10;
    public float mpCost = 0;
    public float SpellID;
    public Sprite Icon;
    public int Animation_ID=5;
    public float value=5;
    public bool is_Available=true;
    public bool is_Damage = true;
    public bool is_Active = true;
    public Buff buff;

    public void Copy(Skills other)
    {
        other.skillName = this.skillName;
        other.CoolTime = this.CoolTime;
        other.mpCost = this.mpCost;
        other.SpellID= this.SpellID;
        other.Icon= this.Icon;
        other.Animation_ID = this.Animation_ID;
        other.is_Available = this.is_Available;
        other.is_Damage = this.is_Damage;
        other.is_Active = this.is_Active;
    }
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
        float cooltime = CoolTime;
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


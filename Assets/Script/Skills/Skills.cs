using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Image Slot;


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
    public void Use(Character parent)
    {
        if (parent.TargetDIstance(parent, parent.target) > parent.status.Range)
        {
            Debug.Log("대상이 너무 멀리 있습니다.");
        }
        else
        {
            Debug.Log(parent.name + "가" + this.skillName + " 스킬 사용");
            parent.StartCoroutine(Use_Skill(parent, parent.target));
            is_Available = false;
            this.cooldown(parent);
        }
    }
    public virtual IEnumerator Use_Skill(Character user, Character target)
    {
        yield return null;
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
            if (Slot != null)
                Slot.fillAmount = 1 - (cooltime / CoolTime);
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  class Items
{
    public string Item_name;
    public int Item_No;
    public bool is_Breakable = true;
    public int Price;
    public string Item_info;
    public string Tag;
    public float CoolTime = 10;
    public int Amount = 1;
    public bool is_Available = true;
    protected Sprite icon;
    public int Value = 5;
    public bool is_Damage = false;


    public Sprite ICON
    {
        get
        {
            return icon;
        }
    }


    public void Copy(Items other)
    {
        Item_name= other.Item_name ;
        Item_No = other.Item_No ;
        is_Breakable=other.is_Breakable ;
        Price=other.Price;
        Item_info =other.Item_info;
        Tag=other.Tag ;
        CoolTime=other.CoolTime;
        Amount=other.Amount;
        icon=other.icon;
        Value = other.Value;
        is_Damage = other.is_Damage;

    }
    public void Copy_to(Items other)
    {
        other.Item_name=Item_name;
        other.Item_No=Item_No;
        other.is_Breakable=is_Breakable;
        other.Price = Price;
        other.Item_info=Item_info;
        other.Tag=Tag;
        other.CoolTime=CoolTime;
        other.Amount=Amount;
        other.icon=icon;
        other.Value=Value;
        other.is_Damage=is_Damage;
    }

    public void Use(Character parent)
    {
        Debug.Log(parent.name + "가 " + this.Item_name + " 아이템 사용 "+(this.Amount-1)+"개 남음");
        parent.StartCoroutine(Use_Item(parent));
        is_Available = false;
    }
    public virtual IEnumerator Use_Item(Character user)
    {
        yield return null;
    }

    public virtual void Awake()
    {
       
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
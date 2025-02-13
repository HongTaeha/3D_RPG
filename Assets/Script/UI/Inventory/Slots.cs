﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Slots : MonoBehaviour
{
    private Rect rect;
    public Rect RECT { get { return rect; } }
    private RectTransform rt;
    public Image Icon;
    public Player player;
    int slot_num=-2;
    public Text text;
    public string ICONNAME
    {
        get
        {
            return Icon.sprite.name;
        }
    }
    public int SLOTNUM
    {
        get
        {
            if (slot_num == -2)
            {
                
                string iconname = this.name;
                string slotname = Regex.Replace(iconname, @"\D", "");
                if (slotname != "")
                    slot_num = int.Parse(slotname);
                else
                    slot_num = -1;
               
            }
            return slot_num;
        }
    }
    public Sprite ICON
    {
        set { Icon.sprite = value; }
    }

    public GameObject ICONGAMEOBJECT
    {
        get { return Icon.gameObject; }
    }

    private void Awake()
    {
    }
    void Start()
    {
        rt = GetComponent<RectTransform>();
        rect.x = rt.position.x - rt.rect.width / 2;
        rect.y = rt.position.y + rt.rect.height / 2;
        rect.xMax = rt.rect.width;
        rect.yMax = rt.rect.height;
        rect.width = rt.rect.width;
        rect.height = rt.rect.height;
        
        
        if(player.inven.Count>= SLOTNUM)
        {
            setIcon();
        }
    }

    public void setIcon()
    {
        if (SLOTNUM >= 0)
        {
            if (player.inven.Exists(SLOTNUM))
            {
                ICON = player.inven.Inven[SLOTNUM].con.ICON;
                OnIcon();
            }
            else
            {
                ICON = null;
                OffIcon();
            }
        }
    }



    public void OffIcon()
    {
        Icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void OnIcon()
    {
        Icon.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
    }

    public bool IsInRect(Vector2 pos)
    {
        // 자신의 rect 영역안에 있다면 
        if (pos.x >= rect.x &&
            pos.x <= rect.x + rect.width &&
            pos.y >= rect.y - rect.height &&
            pos.y <= rect.y)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        if(SLOTNUM>=0)
        if (Icon.gameObject.activeSelf)
        {
            if (player.inven.Is_consume(SLOTNUM))
                text.text = player.inven.Findbynum(SLOTNUM).con.Amount.ToString();
        }
        
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    private Rect rect;
    public Rect RECT { get { return rect; } }
    private RectTransform rt;
    public Image Icon;
    public Player player;
    int slot_num=-2;
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
                string[] parse = this.name.Split('_');
                if (parse[1] == "empty")
                    slot_num = -1;
                else
                    slot_num = int.Parse(parse[1]);
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
        Icon = GetComponentInChildren<Image>();
    }
    void Start()
    {
        rt = GetComponent<RectTransform>();
        // rc.x = tr.position.x - sizeDelta.x / 2;
        rect.x = rt.position.x - rt.rect.width / 2;
        rect.y = rt.position.y + rt.rect.height / 2;
        rect.xMax = rt.rect.width;
        rect.yMax = rt.rect.height;
        rect.width = rt.rect.width;
        rect.height = rt.rect.height;

        Debug.Log(player.inven.Count);
        /*
        if(player.inven.Count>= SLOTNUM + 1)
        {
            if(player.inven.Exists(SLOTNUM))
            ICON = player.inven.Inven[SLOTNUM].con.ICON;
        }*/
    }

    public void OffIcon()
    {
        Icon.gameObject.SetActive(false);
    }

    public void OnIcon()
    {
        Icon.gameObject.SetActive(true);
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

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    private Rect rc;
    public Rect RECT { get { return rc; } }
    private RectTransform tr;
    public Image Icon;
    public Player player;
    int slot_num;
    public string ICONNAME
    {
        get
        {
            return Icon.sprite.name;
        }
    }

    public Sprite ICON
    {
        // sprite는 메모리상에 있는 sprite이어야만 한다.
        // 주의) 화면상의 게임오브젝트를 복사하는 것이 아니라 
        // 메모리상(Resources.Load함수를 이용해서 로드한)의 리소스를 대입해야 한다.
        set { Icon.sprite = value; }

    }

    public GameObject ICONGAMEOBJECT
    {
        get { return Icon.gameObject; }
    }

    void Start()
    {
        tr = GetComponent<RectTransform>();
        // rc.x = tr.position.x - sizeDelta.x / 2;
        rc.x = tr.position.x - tr.rect.width / 2;
        rc.y = tr.position.y + tr.rect.height / 2;
        rc.xMax = tr.rect.width;
        rc.yMax = tr.rect.height;
        rc.width = tr.rect.width;
        rc.height = tr.rect.height;

        

        string[] parse = this.name.Split('_');
        if (parse[1] == "empty")
            slot_num = -1;
        else
            slot_num = int.Parse(parse[1]);
        Debug.Log(player.Inventory.Count);
        if(player.Inventory.Count>0)
        {
            ICON = player.Inventory[slot_num].icon;
        }

    }

    public void OffIcon()
    {
        Icon.gameObject.SetActive(false);
    }

    public void OnIcon()
    {
        Icon.gameObject.SetActive(true);
    }

    public bool IsInRect(Vector2 uipos)
    {
        // 자신의 rect 영역안에 있다면 
        if (uipos.x >= rc.x &&
            uipos.x <= rc.x + rc.width &&
            uipos.y >= rc.y - rc.height &&
            uipos.y <= rc.y)
        {
            return true;
        }
        return false;
    }

    void Update()
    {

    }
}

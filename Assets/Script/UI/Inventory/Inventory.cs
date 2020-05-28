using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private List<Slots> slots = new List<Slots>();
    public Image MoveIcon;
    int workSlot = -1; // 현재 선택한 슬롯 번호
    public Player player;
    void Start()
    {
        Slots[] slot =this.GetComponentsInChildren<Slots>();
        foreach(Slots s in slot)
        {
            if(s.SLOTNUM>=0)
            slots.Add(s);
        }        
    }
    public void cleanup()
    {
        foreach(Slots s in slots)
        {
            s.setIcon();
        }
    }
    public void OnDrag(PointerEventData data)
    {
        MoveIcon.rectTransform.position = data.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        MoveIcon.rectTransform.position = eventData.position;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 UiPos = eventData.position;
        MoveIcon.rectTransform.position = UiPos;
        // 터치한 슬롯을 검색
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsInRect(UiPos))
            {
                //비어있는 슬롯을 눌렀을 경우
                if (slots[i].ICONGAMEOBJECT.gameObject.activeSelf == false)
                    return;
                MoveIcon.gameObject.SetActive(true);
                if (player.inven.Is_consume(i))
                {
                    MoveIcon.sprite = player.inven.Findbynum(i).con.ICON;
                }
                else
                {
                    MoveIcon.sprite = player.inven.Findbynum(i).equip.ICON;
                }
                player.inven.Findbynum(i).num = i;
                slots[i].OffIcon();
                workSlot = i;
                break;
            }
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Vector2 uiPos = eventData.position;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsInRect(uiPos))
            {
                //드래그 안하고 바로 놓을 때
                if (i == workSlot)
                {
                    slots[workSlot].ICONGAMEOBJECT.SetActive(true);
                    MoveIcon.sprite = null;
                    MoveIcon.gameObject.SetActive(false);
                    workSlot = -1;
                }
                break;
            }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 Uipos = eventData.position;

        // 내려놓는 곳의 슬롯을 찾고
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsInRect(Uipos))
            {
                if (workSlot == -1)
                {
                    return;
                }

                //1. 기존아이템이 없는 경우
                if (slots[i].ICONGAMEOBJECT.activeSelf == false)
                {
                    if (player.inven.Is_consume(workSlot))
                    {
                        slots[i].ICON = player.inven.Findbynum(workSlot).con.ICON;
                    }
                    else
                        slots[i].ICON = player.inven.Findbynum(workSlot).equip.ICON;
                    player.inven.Findbynum(workSlot).num = i;
                    slots[i].OnIcon();
                    slots[workSlot].ICON = null;
                    slots[workSlot].OffIcon();
                }
                else
                {
                    //2. 기존아이템이 있는 경우
                    slots[i].OnIcon();
                    slots[workSlot].OnIcon();

                    slots[workSlot].ICON = player.inven.Findbynum(i).con.ICON;
                    slots[i].ICON = player.inven.Findbynum(workSlot).con.ICON;
                    player.inven.Swapnum(i, workSlot);

                }
                MoveIcon.gameObject.SetActive(false);
                workSlot = -1;
                return;
            }
        }
        if(workSlot!=-1)
        slots[workSlot].OnIcon();
        MoveIcon.sprite = null;
        MoveIcon.gameObject.SetActive(false);
        workSlot = -1;
    }


    void Update()
    {

    }
}

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
        //slots.Sort((x, y) => x.name.CompareTo(y.name));
        
    }
    public void OnDrag(PointerEventData data)
    {
        MoveIcon.rectTransform.position = data.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        MoveIcon.rectTransform.position = eventData.position;
    }

    /****************************************************
     * 마우스 , 터치,  다운시 호출
     ****************************************************/
    public void OnPointerDown(PointerEventData eventData)
    {
        // 눌려질때의 위치
        //Debug.Log(eventData.position);
        Vector2 UiPos = eventData.position;
        // MoveIcon의 위치를 터치한 위치로 이동 
        MoveIcon.rectTransform.position = UiPos;

        // 터치한 슬롯을 검색
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsInRect(UiPos))
            {
                // MoveIcon에 적용(MoveIcon을 활성화)
                // 실시간 로드하여 스프라이트를 MoveIcon에 대입
                // 구조화 필요 : ResourceManager(매니저클래스)를 제작하여 검색하여
                // 가져오기
                //비어있는 슬롯을 눌렀을 경우
                if (slots[i].ICONGAMEOBJECT.gameObject.activeSelf == false)
                    return;

                MoveIcon.gameObject.SetActive(true);
                //MoveIcon.sprite = Resources.Load<Sprite>("Icon/" + slots[i].ICONNAME);
                MoveIcon.sprite = player.inven.Inven[i].con.ICON;
                slots[i].OffIcon();
                workSlot = i;
                break;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector2 uiPos = eventData.position;
        //int index = -1;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsInRect(uiPos))
            {
                //내려놓는 곳의 슬롯 번호를 찾고
                //index = i;
                //조건비교

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
                // if ( slots[i].ICONNAME.Equals(string.Empty) )
                if (slots[i].ICONGAMEOBJECT.activeSelf == false)
                {
                    // 이동중인 아이콘 정보를 가져와서
                    // 내려놓는 곳에 아이콘에 대입
                    // 이동중인 아이콘은 없도록 설정
                    //slots[i].ICON = Resources.Load<Sprite>("Icon/" + slots[workSlot].ICONNAME);

                    slots[i].ICON = player.skillbook[workSlot].Icon;

                    slots[i].OnIcon();
                    slots[workSlot].ICON = null;
                    slots[workSlot].OffIcon();
                }
                else
                {
                    //2. 기존아이템이 있는 경우
                    // 내려놓는 곳과 옮기는곳의 아이템을 교체
                    string strTmp = slots[workSlot].ICONNAME;
                    slots[workSlot].ICONGAMEOBJECT.SetActive(true);
                    slots[workSlot].ICON = Resources.Load<Sprite>("Icon/" + slots[i].ICONNAME);
                    slots[i].ICON = Resources.Load<Sprite>("Icon/" + strTmp);

                }
                MoveIcon.gameObject.SetActive(false);
                workSlot = -1;
                return;
            }
        }

        slots[workSlot].OnIcon();
        MoveIcon.sprite = null;
        MoveIcon.gameObject.SetActive(false);
        workSlot = -1;
    }


    void Update()
    {

    }
}

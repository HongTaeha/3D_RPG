using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private List<Slots> slots = new List<Slots>();
    public Image MoveIcon;
    int iWorkSlot = -1; // 현재 선택한 슬롯 번호

    void Start()
    {
        Slots[] slot =this.transform.parent.GetComponentsInChildren<Slots>();
        foreach(Slots s in slot)
        {
            slots.Add(s);
        }
        slots.Sort((x, y) => x.name.CompareTo(y.name));

    }

    /****************************************************
     * 마우스 , 터치,  다운시 호출
     ****************************************************/
    public void OnPointerDown(PointerEventData eventData)
    {
        // 눌려질때의 위치
        Debug.Log(eventData.position);
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
                MoveIcon.sprite = Resources.Load<Sprite>("Icon/" + slots[i].ICONNAME);
                MoveIcon.gameObject.SetActive(true);
                slots[i].OffIcon();
                iWorkSlot = i;
                break;
            }
        }
    }

    public void OnDrag(PointerEventData data)
    {
        MoveIcon.rectTransform.position = data.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 Uipos = eventData.position;

        // 내려놓는 곳의 슬롯을 찾고
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsInRect(Uipos))
            {
                //1. 기존아이템이 없는 경우
                //                if ( slots[i].ICONNAME.Equals(string.Empty) )
                if (slots[i].ICONGAMEOBJECT.activeSelf == false)
                {
                    // 이동중인 아이콘 정보를 가져와서
                    // 내려놓는 곳에 아이콘에 대입
                    // 이동중인 아이콘은 없도록 설정
                    slots[i].ICON = Resources.Load<Sprite>("Icon/" + slots[iWorkSlot].ICONNAME);
                    slots[i].OnIcon();

                    MoveIcon.gameObject.SetActive(false);
                    slots[iWorkSlot].ICON = null;
                    slots[iWorkSlot].OffIcon();
                    iWorkSlot = -1;
                    break;
                }
                else
                {
                    //2. 기존아이템이 있는 경우
                    // 내려놓는 곳과 옮기는곳의 아이템을 교체
                    string strTmp = slots[iWorkSlot].ICONNAME;

                    slots[iWorkSlot].ICONGAMEOBJECT.SetActive(true);
                    slots[iWorkSlot].ICON = Resources.Load<Sprite>("Icon/" + slots[i].ICONNAME);
                    slots[i].ICON = Resources.Load<Sprite>("Icon/" + strTmp);
                    MoveIcon.gameObject.SetActive(false);
                    iWorkSlot = -1;
                }


            }
        }
    }

    void Update()
    {

    }
}

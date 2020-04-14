using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public Player player;

    void MousePick()
    {
        //마우스 버튼에 따른 설정
        // 오른쪽 클릭 : 이동
        // 왼쪽 클릭 : 대상 설정
        
        //오른쪽 클릭
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Terrain"))
                {
                    // 배경을 눌렀을 경우 타겟 변화 없음
                    // 오로지 이동만
                    
                    player.POS = hit.point;
                }
                else if (hit.collider.CompareTag("Enemy"))
                {
                    // 적을 눌렀을경우
                    // 적에게 다가가고 타겟 바꾸고 공격
                    player.POS= hit.collider.transform.position;
                    player.target = hit.collider.gameObject.GetComponent<Character>();

                }
            }
        }
        //왼쪽 클릭
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Terrain"))
                {
                    player.target = null;
                }
                else if (hit.collider.CompareTag("Enemy"))
                {
                    player.target = hit.collider.gameObject.GetComponent<Character>();
                }
            }
        }

                    if (Input.GetKey(KeyCode.W))
        {
            player.POS = player.transform.position;
            player.POS += Vector3.forward* speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.POS = player.transform.position;
            player.POS+= Vector3.left* speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.POS = player.transform.position;
            player.POS += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.POS = player.transform.position;
            player.POS += Vector3.right * speed * Time.deltaTime;
        }

        
        //점프 구현
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("점프");
            player.GetComponent<Rigidbody>().velocity = new Vector2(player.GetComponent<Rigidbody>().velocity.x,5.0f);
        }

        player.Move(player, player.POS);
    }




  

    void Start()
    {
    }
    void Update()
    {
        MousePick();
    }
}

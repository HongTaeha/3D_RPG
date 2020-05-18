using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    //인풋 매니저
    public Player player;
    float speed = 3.0f;
    KeyCode key;
    void Movement()
    {
        //마우스 버튼에 따른 설정
        // 오른쪽 클릭 : 이동
        // 왼쪽 클릭 : 대상 설정

        //오른쪽 클릭
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("오른클릭");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("ground"))
                {
                    // 배경을 눌렀을 경우 타겟 변화 없음
                    // 오로지 이동만
                    player.POS = hit.point;
                    if (player.Attack_Target)
                        player.Attack_Target = null;
                }
                else if (hit.collider.CompareTag("Enemy"))
                {
                    // 적을 눌렀을경우
                    // 적에게 다가가고 타겟 바꾸고 공격                    
                    player.POS = hit.collider.transform.position;
                    player.target = hit.collider.gameObject.GetComponent<Character>();
                    player.Attack_Target = hit.collider.gameObject.GetComponent<Character>();
                }
            }
        }
        if (Input.GetKey(KeyCode.W))
        {               
            player.Navi.Move(player.transform.forward * Time.deltaTime*speed);
            poscon();
        }        
        if (Input.GetKey(KeyCode.S))
        {           
            player.Navi.Move(player.transform.forward * Time.deltaTime * speed * (-1));
            poscon();
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.Rotate(player, player.transform.position + player.transform.right * (-1) * Time.deltaTime, speed);
            poscon();
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.Rotate(player, player.transform.position + player.transform.right* Time.deltaTime ,speed);
            poscon();
        }
        //점프 구현
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            //player.GetComponent<Rigidbody>().velocity = new Vector2(player.GetComponent<Rigidbody>().velocity.x,5.0f);
        }
    }
    void poscon()
    {
        player.POS = player.transform.position;
        player.Navi.SetDestination(player.transform.position);
        player.ani.SetInteger("iAniIndex", 1);
    }  
    void targetcontroll()
    {
        //왼쪽 클릭
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("왼클릭");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Terrain"))
                {
                    player.target = null;
                }
                else if (hit.collider.CompareTag("Enemy")|| hit.collider.CompareTag("Player") || hit.collider.CompareTag("NPC"))
                {
                    player.target = hit.collider.gameObject.GetComponent<Character>();
                }
            }
        }
        //esc키로 목표 타겟 제거
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.target = null;
        }
    }
    void Start()
    {
    }
    void Update()
    {
       
        targetcontroll();
        Movement();

        if (player.transform.position != player.POS)
        {
            player.Move(player, player.POS);
            player.Rotate(player, player.POS);
        }


    }
}

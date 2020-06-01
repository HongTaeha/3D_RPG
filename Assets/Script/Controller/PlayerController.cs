using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerController : Controller
{
    //인풋 매니저
    public Player player;
    float speed = 3.0f;
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
        if (player.is_Automatic)
        {
            Automatic();
        }
        else
        {
            targetcontroll();
            Movement();            
        }

        if (player.transform.position != player.POS)
        {
            player.Move(player, player.POS);
            player.Rotate(player, player.POS);
        }

    }
    public Toggle t;
    void Automatic()
    {
        /* 1. 지역의 몬스터 리스트를 갖고 온다 
         * 2. 몬스터별로 거리를 계산한다
         * 3. 가까운 몬스터별로 잡으러 간다
         * 4. 중간에 피가 떨어지면 포션을 마신다.
         * 5. 스킬 쿨타임이 되면 바로 쓴다.*/
        Cal_Distance();
        if (player.target != null)
        {
            if (!player.target.isActiveAndEnabled)
            {
                player.target = null;
            }
            else
            {
                if(player.TargetDIstance(player,player.target)<player.status.Range)
                if (player.skillbook.Count > 0)
                {
                    if (player.target != null)
                        if (player.Attack_Target.status.HP > player.skillbook[0].value)
                            player.Use_Skill(0);
                }
                if (player.status.HP < player.status.Max_HP - 5)
                {
                    if (player.inven.Count>0)
                        player.Use_Item(0);
                }
            }

        }
    }

    class disLst
    {
        public GameObject obj;
        public float distance;
    }
    bool GetPath(NavMeshPath path, Vector3 fromPos, Vector3 toPos, int passableMask)
    {
        path.ClearCorners();
        if (NavMesh.CalculatePath(fromPos, toPos, passableMask, path) == false)
            return false;
        return true;
    }

    float GetPathLength(NavMeshPath path)
    {
        float lng = 0.0f;
        if ((path.status != NavMeshPathStatus.PathInvalid) && (path.corners.Length > 1))
        {
            for (int i = 1; i < path.corners.Length; ++i)
            {
                lng += Vector3.Distance(path.corners[i - 1], path.corners[i]);
            }
        }
        return lng;
    }
    void Cal_Distance()
    {
        ObjectPooler.instance.getActiveObject("Enemy",out List<GameObject> activeobj);
        List<disLst> lst = new List<disLst>();
        foreach (GameObject a in activeobj)
        {
            disLst tmp = new disLst();
            tmp.obj = a;
            NavMeshPath t = new NavMeshPath();
            if(GetPath(t, player.transform.position, a.transform.position, -1))
            {
                tmp.distance = GetPathLength(t);
            }
            else
            {
                tmp.distance = Mathf.Infinity;
            }
            lst.Add(tmp);
        }
        lst.Sort((x, y) => x.distance.CompareTo(y.distance));
        if (lst.Count == 0)
        {
            Debug.Log("자동사냥 끝");
            t.isOn = false;
            player.is_Automatic = false;
        }
        else
        {
            player.target = lst[0].obj.GetComponent<Enemy>();
            player.Attack_Target = player.target;
            player.POS = player.target.transform.position;
        }
    }
}

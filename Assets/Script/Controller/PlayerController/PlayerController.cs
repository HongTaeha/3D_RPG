using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public Player player;

    void MousePick()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Terrain"))
                {
                    player.POS = hit.point;
                    player.t_pos = null;
                }
                else if (hit.collider.CompareTag("Enemy"))
                {
                    player.POS= hit.collider.transform.position;
                    player.t_pos = hit.collider.transform;
                    //player.target = hit.collider.gameObject.GetComponent<Character>();
                }
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            player.POS += Vector3.forward* speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {

            player.POS+= Vector3.left* speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {

            player.POS += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.POS += Vector3.right * speed * Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            player.POS = player.transform.position;
        }

        //점프 구현
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.GetComponent<Rigidbody>().velocity = new Vector2(player.GetComponent<Rigidbody>().velocity.x,5.0f);
        }

        Move(player, player.POS);
    }




    public void Move(Character obj, Vector3 _pos)
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, _pos, Time.deltaTime * speed);
        if (obj.transform.position == _pos)
        {
            //애니메이션 지정

            ani.SetInteger("iAniIndex", 0);
        }
    }

    public void Rotate(Character obj, Vector3 _pos)
    {
        Vector3 targetDir = _pos - obj.transform.position;
        if (Vector3.Dot(targetDir.normalized, obj.transform.forward).CompareTo(0.99f) >= 0)
            return;

        Vector3 newDir = Vector3.RotateTowards(obj.transform.forward, targetDir.normalized, Time.deltaTime * 4f, 0);
        obj.transform.rotation = Quaternion.LookRotation(newDir);
    }

    void Start()
    {
        ani = player.GetComponent<Animator>();
    }
    void Update()
    {
        MousePick();
    }
}

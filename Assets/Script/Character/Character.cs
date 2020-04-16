using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //중력
    float gravity = 9.8f;




    //목표 대상 구현
    public Character target = null;
    public Vector3 targetpos //디버그용
    {
        get
        {
            if (target != null)
                return target.transform.position;
            else
                return transform.position;
        }
    }
    public Vector3 mypos; 

    public Transform t_pos
    {
        get
        {
            if (target != null)
                return target.transform;
            else
                return null;
        }
    }
    public float TargetDIstance
    {
        get
        {

            return Vector3.Distance(transform.position, target.transform.position);

        }

    }

    //애니메이션
    public Animator ani;
    public float speed = 3.0f;
    private Vector3 pos = Vector3.zero;
    public Vector3 POS
    {        
            get { return pos; }
            set { pos= value; }
    }



    //케릭터 스텟
    public string StrName;
    public float Range;
    public float HP;
    public float MP;



    void Start()
    {
       
    }


    void Update()
    {


    }

    public void  Move(Character obj, Vector3 _pos)
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

        Vector3 newDir = Vector3.RotateTowards(obj.transform.forward, targetDir.normalized, Time.deltaTime * speed, 0);
        obj.transform.rotation = Quaternion.LookRotation(newDir);
    }
   
}

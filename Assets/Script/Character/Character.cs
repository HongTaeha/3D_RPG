using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

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
    

    //애니메이션
    public Animator ani;
    float speed = 3.0f;
    private Vector3 pos = Vector3.zero;
    public Vector3 POS
    {        
            get { return pos; }
            set { pos= value; }
    }
    public bool Is_Battle = false;
    public bool is_Move = false;



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
    public float TargetDIstance(Character obj,Character target)
    {

        return Vector3.Distance(obj.transform.position, target.transform.position);
        
    }

    public void  Move(Character obj, Vector3 _pos)
    {

        obj.transform.position = Vector3.MoveTowards(obj.transform.position, _pos, Time.deltaTime * speed);
        
        if (obj.transform.position == _pos)
        {
            ani.SetInteger("iAniIndex", 0);
        }
    }

    public void Rotate(Character obj, Vector3 _pos)
    {
        Vector3 targetDir = _pos - obj.transform.position;
        if (Vector3.Dot(targetDir.normalized, obj.transform.forward).CompareTo(0.99f) >= 0)
            return;

        Vector3 newDir = Vector3.RotateTowards(obj.transform.forward, targetDir.normalized, Time.deltaTime * 10, 0);
        obj.transform.rotation = Quaternion.LookRotation(newDir);
    }
   
}

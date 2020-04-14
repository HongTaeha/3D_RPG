using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator ani;
    public float speed = 3.0f;

    private Vector3 pos = Vector3.zero;

    public Vector3 POS
    {        
            get { return pos; }
            set { pos= value; }
    }

    public Character target = null;
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
        get{
           
                return Vector3.Distance(transform.position, target.transform.position);
           
        }
    
    }

    public string StrName;
    public float Range;
    public float HP;
    public float MP;

    void Start()
    {
        ani = GetComponent<Animator>();
        POS = transform.position;

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

        Vector3 newDir = Vector3.RotateTowards(obj.transform.forward, targetDir.normalized, Time.deltaTime * 10f, 0);
        obj.transform.rotation = Quaternion.LookRotation(newDir);
    }

}

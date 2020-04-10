using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Animator ani;

    private Vector3 pos = Vector3.zero;

    public Vector3 POS
    {        
            get { return pos; }
            set { pos= value; }
    }

    public Character target = null;
    public Transform t_pos = null;
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



}

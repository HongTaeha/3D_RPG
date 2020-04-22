using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : Controller
{

    Character ch;
    public void HitEvent()
    {
        //ch.Attack_Target.Take_Damage(1);
        Debug.Log("1");
    }

    // Start is called before the first frame update
    void Start()
    {
        ch = GameObject.Find("Mummy").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}

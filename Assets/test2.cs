using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{

    public Player enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(enemy.Attack_Target)
        transform.position = enemy.Attack_Target.transform.position;
        Debug.Log(transform.position);
    }
}

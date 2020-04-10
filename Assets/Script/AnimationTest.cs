using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // idle
            ani.SetInteger("iAniIndex", 0);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ani.SetInteger("iAniIndex", 1);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            ani.SetInteger("iAniIndex", 2);
        }

    }
}

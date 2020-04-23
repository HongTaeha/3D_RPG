using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyIdle : StateMachineBehaviour
{
    Mummy cha = null;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (cha == null)
        {
            cha = animator.GetComponent<Mummy>();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (cha.target != null)
        {
            if( cha.TARGETDISTANCE < cha.fAttackRange)
            {
                animator.SetInteger("iAniIndex", 2);
            }
            else
            {
                animator.SetInteger("iAniIndex", 1);
            }
        }
        else
        {
            if (cha.transform.position != cha.vEND)
            {
                animator.SetInteger("iAniIndex", 1);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("========= OnStateExit");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

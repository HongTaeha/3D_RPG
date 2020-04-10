using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyWalk : StateMachineBehaviour
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
        Vector3 vEnd = Vector3.zero;
        if (cha.target != null)
        {
            vEnd = cha.target.transform.position;
            if(cha.TARGETDISTANCE < cha.fAttackRange )
            {
                animator.SetInteger("iAniIndex", 2);
            }
        }
        else if (cha.target == null)
        {
            vEnd = cha.vEND;
        }
        cha.Move(vEnd);
        cha.Rotate(vEnd);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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

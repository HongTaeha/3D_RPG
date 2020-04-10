using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyAttack : StateMachineBehaviour
{
    Mummy cha = null;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (cha == null)
        {
            cha = animator.GetComponent<Mummy>();
        }
        cha.vEND = cha.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (cha.target == null)
        {
            if (cha.vEND != cha.transform.position)
            {
                animator.SetInteger("iAniIndex", 1);
            }
            // 타겟의 Hp가 0이라면
            //animator.SetInteger("iAniIndex", 0);
        }
        else
        {
            if( cha.TARGETDISTANCE > cha.fAttackRange )
            {
                //추격
                animator.SetInteger("iAniIndex", 1);
            }
            cha.Rotate(cha.target.transform.position);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cha.vEND = cha.transform.position;
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

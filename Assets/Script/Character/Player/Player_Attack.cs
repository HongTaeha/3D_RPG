using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : StateMachineBehaviour
{
    Player player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player== null)
        {
            player = animator.GetComponent<Player>();
        }
        //요거때매 한번만 공격하는거같은데
        player.POS= player.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.target == null)
        {
            if (player.POS != player.transform.position)
            {
                animator.SetInteger("iAniIndex", 1);
            }
            // 타겟의 Hp가 0이라면
            if(player.target.HP==0)
                animator.SetInteger("iAniIndex", 0);
        }
        else
        {
            if (player.TargetDIstance> player.Range)
            {
                //추격
                animator.SetInteger("iAniIndex", 1);
            }
            player.Rotate(player,player.t_pos.position);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
            player.POS = player.t_pos.position;
        
        
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_idle : StateMachineBehaviour
{
    Player player = null;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
        {
            player = animator.GetComponent<Player>();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.target != null)
        {
            if (player.TargetDIstance< player.Range)
            {
                animator.SetInteger("iAniIndex", 2);
            }
            else
            {
                player.Rotate(player, player.t_pos.position);
                animator.SetInteger("iAniIndex", 1);
            }
        }
        else
        {
            if (player.transform.position != player.POS)
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

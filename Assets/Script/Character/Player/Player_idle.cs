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
        
            //player.Rotate(player, player.target.transform.position);
            if (player.Attack_Target !=null)
            {
                if (player.TargetDIstance(player,player.Attack_Target) < player.Range)
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

            if(player.transform.position!=player.POS)
            {
                animator.SetInteger("iAniIndex", 1);
            }
        }

    }

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

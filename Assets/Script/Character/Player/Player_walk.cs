using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_walk : StateMachineBehaviour
{
    Player player = null;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player== null)
        {
            player = animator.GetComponent<Player>();
        }
       
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 vEnd = Vector3.zero;
        if (player.target != null)
        {
            vEnd = player.target.transform.position;
            if (player.TargetDIstance< player.Range)
            {

               // player.Rotate(player, vEnd);
                animator.SetInteger("iAniIndex", 2);
            }
        }
        else if (player.target == null)
        {
            vEnd = player.POS;
            if (player.POS != player.transform.position)
            {
                //player.Rotate(player, vEnd);
            }
        }
        //player.Move(player,vEnd);
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

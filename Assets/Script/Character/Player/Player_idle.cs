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
        //가만히 있을 때
        //공격대상이 있으면
        if (player.Attack_Target !=null)
        {

            //사거리가 닿을 때
            if (player.TargetDIstance(player,player.Attack_Target) < player.status.Range)
            {
                //공격
                //animator.SetInteger("iAniIndex", 2);
                player.StartAttack();
            }
            //안닿으면
            else
            {
                //추적
                animator.SetInteger("iAniIndex", 1);
            }
        }
        //공격대상이 없으면
        else
        {
            //이동
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

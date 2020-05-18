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
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.Navi.SetDestination(player.transform.position);
        if (player.Attack_Target!=null) //공격타겟이 있을때
        {
            //공격중에          
            if (player.Attack_Target.status.HP <= 0)
            {
                player.EndAttack();
                player.POS = player.transform.position;
                player.Attack_Target = null;
                animator.SetInteger("iAniIndex", 0);
            }
            //대상이 안죽었으면
            else
            {
                //사거리 안에 있다
                if (player.TargetDIstance(player, player.Attack_Target) < player.status.Range)
                {
                    //공격 대상을 본다                
                    //player.Rotate(player, player.Attack_Target.transform.position); 
                    
                }
                //대상이 사거리 안에 없으면
                else
                {
                    //추격
                    player.EndAttack();
                    animator.SetInteger("iAniIndex", 1);
                }
            }
        }
        else //공격타겟이 없을때
        {
            
            player.EndAttack();
            player.POS = player.transform.position;
            animator.SetInteger("iAniIndex", 0);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.POS = player.transform.position;
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

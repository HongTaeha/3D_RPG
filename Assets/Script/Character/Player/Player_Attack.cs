using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : StateMachineBehaviour
{
    Player player;
    Vector3 temp = Vector3.zero;
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
        if (player.Attack_Target!=null) //공격타겟이 있을때
        {
            //공격중에
            //다른 곳이 클릭되면
            if (player.POS != player.Attack_Target.transform.position)
            {
                player.EndAttack();
                player.Attack_Target = null;
                animator.SetInteger("iAniIndex", 1);
            }
            else
            {
                //대상이 사거리 안에 있으면
                if (player.TargetDIstance(player, player.Attack_Target) < player.Range)
                {
                    player.Rotate(player, player.Attack_Target.transform.position); //공격 대상을 본다
                }

                //대상이 사거리 안에 없으면
                else
                {
                    //추격
                    player.EndAttack();
                    player.POS = player.Attack_Target.transform.position;
                    animator.SetInteger("iAniIndex", 1);
                }

            }
        }
        else //공격타겟이 없을때
        {
            player.EndAttack();
            player.Is_Battle = false; //전투 중지
            if(player.POS == player.transform.position)
            animator.SetInteger("iAniIndex", 0);
        }
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

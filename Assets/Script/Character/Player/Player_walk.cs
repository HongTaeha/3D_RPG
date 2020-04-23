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
        if (player.Attack_Target != null) //공격 타겟이 있을 때
        {
            vEnd = player.Attack_Target.transform.position; //공격 타겟을 향해서
            if (player.TargetDIstance(player,player.Attack_Target)<= player.status.Range)  //대상이 공격 거리 안에 있을 때
            {
                //player.Rotate(player, vEnd);

                //animator.SetInteger("iAniIndex", 2); //공격
                player.StartAttack();

            }   
        }
        else //공격 타겟이 없을 떄
        {
            vEnd = player.POS;   //자신의 현재 위치를 향해서        
        }

        player.Move(player, vEnd); //이동한다
        player.Rotate(player, vEnd); //돈다
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

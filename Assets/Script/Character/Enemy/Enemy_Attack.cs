using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : StateMachineBehaviour
{
    Enemy enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (enemy == null)
        {
            enemy = animator.GetComponent<Enemy>();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.Navi.SetDestination(enemy.transform.position);
        if (!enemy.target)
        {
            enemy.EndAttack();
            animator.SetInteger("iAniIndex", 0);
        }
        else
        {
            if(enemy.skillbook[0])
            {
                if(enemy.skillbook[0].is_Available)
                {
                    enemy.Use_Skill(0);
                }
            }
            if (enemy.TargetDIstance(enemy, enemy.target) > enemy.status.Range)
            {
                enemy.EndAttack();
                enemy.POS = enemy.target.transform.position;
                animator.SetInteger("iAniIndex", 1);
            }
        }        
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.POS = enemy.transform.position;

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

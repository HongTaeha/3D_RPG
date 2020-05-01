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
        //float fRatio = (stateInfo.normalizedTime % 1f) * 100f;
        
        if (enemy.target == null)
            {
                enemy.Is_Battle = false;
                enemy.Attack_Target = null;
                animator.SetInteger("iAniIndex", 0);
            }
            else
            {
            /*
            if(fRatio>=50&& fRatio <= 51)
            {
                enemy.Attack_Target.Take_Damage(enemy.status.AttackDamage);
            }
            */
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Idle : StateMachineBehaviour
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
        
        if (!enemy.target)
        {
            int nR = Random.Range(0, 10);
            if (nR == 0 || nR == 1 || nR == 2)
            {
                animator.SetInteger("iAniIndex", 1);
            }
        }
        else
        {
            if (enemy.POS != enemy.transform.position)
                animator.SetInteger("iAniIndex", 1);
            if (enemy.TargetDIstance(enemy,enemy.target)<enemy.status.Range)
            {
                enemy.StartAttack();
            }
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!enemy.target)
        {
            NavMeshPath path = new NavMeshPath();
            if (NavMesh.CalculatePath(enemy.transform.position, enemy.POS, -1, path)!=false)
                enemy.Random_spot();
        }

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

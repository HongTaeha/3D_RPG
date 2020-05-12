using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : StateMachineBehaviour
{ 
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{

}

override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
        float fRatio = (stateInfo.normalizedTime % 1f) * 100f;
        Debug.Log("애니메이션 진행률 = " + fRatio.ToString());
       
}
}

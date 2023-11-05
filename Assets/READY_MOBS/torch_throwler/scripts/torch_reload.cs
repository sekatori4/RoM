using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;





public class torch_reload : StateMachineBehaviour
{
   
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetBehaviour<atack_torch>().fakela_est = false;

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetBehaviour<atack_torch>().fakela_est=true;
        
    }



}

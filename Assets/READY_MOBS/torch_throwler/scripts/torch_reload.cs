using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




public class torch_reload : StateMachineBehaviour
{
    



    

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Debug.Log("должен пропасть");

        animator.GetComponent<torch_throw_projectile>().reload_torch();

        


    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }





}

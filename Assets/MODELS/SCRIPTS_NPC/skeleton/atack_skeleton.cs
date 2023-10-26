using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class atack_skeleton : StateMachineBehaviour
{
    GameObject[] castle;
    NavMeshAgent agent;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        agent = animator.GetComponent<NavMeshAgent>();
        castle = GameObject.FindGameObjectsWithTag("castle");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        int blizh = 0;
        for (int i = 0; i < castle.Length; i++)
        {

            if (Vector3.Distance(castle[i].transform.position, agent.transform.position) < Vector3.Distance(castle[blizh].transform.position, agent.transform.position))
            {
                blizh = i;
            }


        }





        animator.transform.LookAt(castle[blizh].transform);
        float distance = Vector3.Distance(animator.transform.position, castle[blizh].transform.position);
        if (distance > 5)
            animator.SetBool("attack", false);

        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}

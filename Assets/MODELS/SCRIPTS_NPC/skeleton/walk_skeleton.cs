using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class walk_skeleton : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform castle;
    float attackRange = 5;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 5;
        List<Transform> targets = new List<Transform>();
        castle = GameObject.FindGameObjectWithTag("castle").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(castle.position);
        float distance = Vector3.Distance(animator.transform.position, castle.position);
        if (distance < attackRange)
            animator.SetBool("attack", true);


           }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}

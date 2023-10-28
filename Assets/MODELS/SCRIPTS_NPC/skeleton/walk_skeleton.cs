using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class walk_skeleton : StateMachineBehaviour
{
    NavMeshAgent agent;
    NavMeshObstacle obtekat;
    GameObject[] castle;
    float attackRange = 5;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();

        obtekat = animator.GetComponent<NavMeshObstacle>();
        agent.speed = 5;
        List<Transform> targets = new List<Transform>();


       

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
               // float a = Vector3.Distance(agent.transform.localScale, agent.transform.localScale);
                blizh = i;
            }


        }






        obtekat.enabled = false;                          //-----------  ÎÁÒÅÊÀÒÜ ÂÛÊË
        agent.enabled = true;                             //-----------  ÀÃÅÍÒ  ÂÊË




        agent.SetDestination(castle[blizh].transform.position);           /// <<<<-------------  ÀÃÅÍÒ ÈÄÅÒ Ê ÁËÈÆÀÉØÅÌÓ ÂÐÀÃÓ
        
        
        float distance = Vector3.Distance(animator.transform.position, castle[blizh].transform.position);
        if (distance < attackRange)
           
        {
            
            animator.SetBool("attack", true);
            
        }
        else
        {
            animator.SetBool("attack", false);
        }

           }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}

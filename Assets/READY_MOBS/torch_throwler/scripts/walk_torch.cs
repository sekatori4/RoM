using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class walk_torch : StateMachineBehaviour
{
    NavMeshAgent agent;
    NavMeshObstacle obtekat;
    GameObject[] deff;
    GameObject[] castle;
    GameObject[] enemy;
    float chaseRange;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();

        obtekat = animator.GetComponent<NavMeshObstacle>();
        agent.speed = 2;
                                    

               
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        deff = GameObject.FindGameObjectsWithTag("deff");
        castle = GameObject.FindGameObjectsWithTag("castle");

        if (deff.Length > 0)

        {
            chaseRange = 40;
            enemy = deff;
        }
            else
        {
            chaseRange = 40;
            enemy = castle;
        }

        int blizh = 0;
        for (int i = 0; i < enemy.Length; i++)
        {

            if (Vector3.Distance(enemy[i].transform.position, agent.transform.position) < Vector3.Distance(enemy[blizh].transform.position, agent.transform.position))
            {
                float a = Vector3.Distance(agent.transform.localScale, agent.transform.localScale);
                blizh = i;
            }


        }






        //obtekat.enabled = false;                          //-----------  ÎÁÒÅÊÀÒÜ ÂÛÊË
       // agent.enabled = true;                             //-----------  ÀÃÅÍÒ  ÂÊË




        agent.SetDestination(enemy[blizh].transform.position);           /// <<<<-------------  ÀÃÅÍÒ ÈÄÅÒ Ê ÁËÈÆÀÉØÅÌÓ ÂÐÀÃÓ
        
        
        float distance = Vector3.Distance(animator.transform.position, enemy[blizh].transform.position);
        if (distance < chaseRange)
           
        {
            
            animator.SetBool("chase", true);
            
        }
        else
        {
            animator.SetBool("chase", false);
        }

           }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}

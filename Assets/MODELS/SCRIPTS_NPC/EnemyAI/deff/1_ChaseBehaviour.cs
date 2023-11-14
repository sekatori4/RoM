using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    NavMeshAgent agent;
    float attackRange = 4;
    GameObject[] enemy;
    NavMeshObstacle obtekat;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 10;
        obtekat = animator.GetComponent<NavMeshObstacle>();                   //---<<<<<----------------   ÎÁÒÅÊÀÒÜ

    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemy = GameObject.FindGameObjectsWithTag("skelet");

        if (enemy.Length > 0)
        {

            int blizh = 0;
            for (int i = 0; i < enemy.Length; i++)
            {

                if (Vector3.Distance(enemy[i].transform.position, agent.transform.position) < Vector3.Distance(enemy[blizh].transform.position, agent.transform.position))
                {
                    // float a = Vector3.Distance(agent.transform.localScale, agent.transform.localScale);
                    blizh = i;
                }


            }



            agent.SetDestination(enemy[blizh].transform.position);
            float distance2 = Vector3.Distance(animator.transform.position, enemy[blizh].transform.position);
            if (distance2 < attackRange)
                animator.SetBool("isattack", true);


            if (distance2 > 40)
                animator.SetBool("isaggro", false);



        }


        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 2;
    }
}

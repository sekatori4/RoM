using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class atack_skeleton : StateMachineBehaviour
{
    GameObject[] castle;
    NavMeshAgent agent;
    NavMeshObstacle obtekat;
    float attackRange = 5;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        obtekat = animator.GetComponent<NavMeshObstacle>();                   //---<<<<<----------------   ÎÁÒÅÊÀÒÜ
        agent = animator.GetComponent<NavMeshAgent>();
        castle = GameObject.FindGameObjectsWithTag("castle");

        if (castle.Length < 1)
        {
            animator.SetBool("atack", false);

        }

        else
        {



            int blizh = 0;
            for (int i = 0; i < castle.Length; i++)
            {

                if (Vector3.Distance(castle[i].transform.position, animator.transform.position) < Vector3.Distance(castle[blizh].transform.position, animator.transform.position))
                {
                    blizh = i;
                }


            }





            animator.transform.LookAt(castle[blizh].transform);  //-----<<< Ñìîòðèò ÍÀ ÖÅËÜ


            //--------------ÂÊËÞ×ÈÒÜ ÍÀÂÌÅØ--ÎÁÒÝÉÊË
            agent.enabled = false;
            obtekat.enabled = true;

            //-------------

            float distance = Vector3.Distance(animator.transform.position, castle[blizh].transform.position);
            if (distance > attackRange)

                //--------------ÎÁÒÝÉÊË---ÂÛÊË




                animator.SetBool("attack", false);  //------> ïåðåõîä íà walk_skeleton


        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class atack_skeleton : StateMachineBehaviour
{
    GameObject[] deff;
    GameObject[] castle;
    GameObject[] enemy;

    NavMeshAgent agent;
    NavMeshObstacle obtekat;
    float attackRange ;
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
        deff = GameObject.FindGameObjectsWithTag("deff");

        if (deff.Length > 0)

        {
            attackRange = 3f;
            enemy = deff;
        }
        else
        {
            attackRange = 5f;
            enemy = castle;
        }




        if (enemy.Length < 1)
        {
            animator.SetBool("atack", false);    // ñäåëàòü ïåðåõîä â àíèìàöèþ WALK à îòòóäà â àíèìàöèþ ÂÈÍÍÅÐ!!!

        }

        else
        {



            int blizh = 0;
            for (int i = 0; i < enemy.Length; i++)
            {

                if (Vector3.Distance(enemy[i].transform.position, animator.transform.position) < Vector3.Distance(enemy[blizh].transform.position, animator.transform.position))
                {
                    blizh = i;
                }


            }





            animator.transform.LookAt(enemy[blizh].transform);  //-----<<< Ñìîòðèò ÍÀ ÖÅËÜ


            //--------------ÂÊËÞ×ÈÒÜ ÍÀÂÌÅØ--ÎÁÒÝÉÊË
            agent.enabled = false;
            obtekat.enabled = true;

            //-------------

            float distance = Vector3.Distance(animator.transform.position, enemy[blizh].transform.position);
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

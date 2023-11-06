using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class walk_skeleton : StateMachineBehaviour
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
        agent.speed = 5;
                                    // List<Transform> targets = new List<Transform>();

               
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        deff = GameObject.FindGameObjectsWithTag("deff");
        castle = GameObject.FindGameObjectsWithTag("castle");

        if (deff.Length > 0 )

        {
            chaseRange = 3;
            enemy = deff;
        }
            else
        {
            chaseRange = 5f;
            enemy = castle;
        }

        int blizh = 0;
        for (int i = 0; i < enemy.Length; i++)
        {

            if (Vector3.Distance(enemy[i].transform.position, agent.transform.position) < Vector3.Distance(enemy[blizh].transform.position, agent.transform.position))
            {
               
                blizh = i;
            }


        }






        obtekat.enabled = false;                          //-----------  �������� ����
        agent.enabled = true;                             //-----------  �����  ���




        agent.SetDestination(enemy[blizh].transform.position);           /// <<<<-------------  ����� ���� � ���������� �����
        
        
        float distance = Vector3.Distance(animator.transform.position, enemy[blizh].transform.position);
        if (distance < chaseRange)
           
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

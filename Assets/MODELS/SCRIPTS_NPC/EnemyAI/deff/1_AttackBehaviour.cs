using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{


    GameObject[] enemy;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemy = GameObject.FindGameObjectsWithTag("skelet");

        if (enemy.Length < 1)
        {
            animator.SetBool("isattack", false);
            animator.SetBool("isaggro", false);

        }

        else
        {



            int blizh = 0;
            for (int i = 0; i < enemy.Length; i++)
            {

                if (Vector3.Distance(enemy[i].transform.position, animator.transform.position) < Vector3.Distance(enemy[blizh].transform.position, animator.transform.position))
                {
                    // float a = Vector3.Distance(agent.transform.localScale, agent.transform.localScale);
                    blizh = i;
                }


            }







            animator.transform.LookAt(enemy[blizh].transform.position);
            float distance = Vector3.Distance(animator.transform.position, enemy[blizh].transform.position);


            if (distance > 5)
                animator.SetBool("isattack", false);

            if (distance > 10)
                animator.SetBool("isaggro", false);


        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}

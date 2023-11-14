using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleBehaviour : StateMachineBehaviour
{
    float timer;
    int randomNumberMIN;
    int randomNumberMAX;
    GameObject[] enemy;
    float chaseRange = 20;

    NavMeshAgent agent;
    NavMeshObstacle obtekat;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        obtekat = animator.GetComponent<NavMeshObstacle>();                   //---<<<<<----------------   ÎÁÒÅÊÀÒÜ
        agent = animator.GetComponent<NavMeshAgent>();
       
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        randomNumberMIN = Random.Range(1, 2);
        randomNumberMAX = Random.Range(4, 5);
        enemy = GameObject.FindGameObjectsWithTag("skelet");

        if (enemy.Length > 0)
        {
            int blizh = 0;
            for (int i = 0; i < enemy.Length; i++)
            {

                if (Vector3.Distance(enemy[i].transform.position, animator.transform.position) < Vector3.Distance(enemy[blizh].transform.position, animator.transform.position))
                {

                    blizh = i;
                }


            }


            timer += Time.deltaTime;
            if (timer > randomNumberMIN && timer < randomNumberMAX)
                animator.SetBool("ispatrolling", true);
           
            float distance = Vector3.Distance(animator.transform.position, enemy[blizh].transform.position);
            if (distance < chaseRange)
                animator.SetBool("isaggro", true);
            
        }


        else
        {

            timer += Time.deltaTime;
            if (timer > randomNumberMIN && timer < randomNumberMAX)
                animator.SetBool("ispatrolling", true);
        }

        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}

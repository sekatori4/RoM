using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    GameObject[] waypoint;


    float timer;
   
    NavMeshAgent agent;
    float speedwalk = 3f;
    GameObject[] enemy;
    float chaseRange = 30;
    NavMeshObstacle obtekat;


    private void Awake()
    {
        waypoint = GameObject.FindGameObjectsWithTag("waypoint");
    }






    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         //points.Clear(); 
        
        timer = 0;

        obtekat = animator.GetComponent<NavMeshObstacle>();
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = speedwalk;

        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = GameObject.FindGameObjectsWithTag("skelet");
               
        if (enemy.Length >0) 
        {

            // ----ближайшая точка>>>>>      

            int blizh = 0;
            for (int i = 0; i < enemy.Length; i++)
            {

                if (Vector3.Distance(enemy[i].transform.position, agent.transform.position) < Vector3.Distance(enemy[blizh].transform.position, agent.transform.position))
                {

                    blizh = i;
                }


            }
            //----------------------------
            if (agent.remainingDistance <= agent.stoppingDistance)


                agent.SetDestination(waypoint[Random.Range(0, waypoint.Length)].transform.position);

            timer += Time.deltaTime;
            if (timer == Random.Range(3,8))
                animator.SetBool("ispatrolling", false);

            float distance = Vector3.Distance(animator.transform.position, enemy[blizh].transform.position);
            if (distance < chaseRange)
                animator.SetBool("isaggro", true);


        }

        else
        {

            if (agent.remainingDistance <= agent.stoppingDistance)

                agent.SetDestination(waypoint[Random.Range(0, waypoint.Length)].transform.position);

            timer += Time.deltaTime;
            if (timer > Random.Range(3, 8))
                animator.SetBool("ispatrolling", false);

        }
       
        
        }



    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class atack_torch : StateMachineBehaviour 
{
    GameObject[] deff;
    GameObject[] castle;
    GameObject[] enemy;

    NavMeshAgent agent;
    NavMeshObstacle obtekat;
    float attackRange ;

    public Vector3 TargetPosition;
    public GameObject ruka_kidat;
    public GameObject boolet;
    public bool fakela_est;
    
    


    //--------------------------------------------------------------------------------------------------------------------------

 
    public void LaunchProjectale(Animator animator)
    {
       animator.GetComponent<torch_throw_projectile>().DoCoroutine();
    }

    //----------------------------------------------------------------------------------------------------------------------------------
   
    //----------------------------------------------------------------------------------------------------------------------------------




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
        ruka_kidat = animator.GetComponent<torch_throw_projectile>().pointshoot;
        boolet = animator.GetComponent<torch_throw_projectile>().torchPrefab;


        if (deff.Length > 0)

        {
            attackRange = 22;
            enemy = deff;
        }
        else
        {
            attackRange = 22;
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

            Vector3 targetPosition = enemy[blizh].GetComponentInChildren<Renderer>().bounds.center;
            animator.GetComponent<torch_throw_projectile>().SetTarget(targetPosition);

            //----------------------------------


            float distance = Vector3.Distance(animator.transform.position, enemy[blizh].transform.position);

            if (distance > attackRange && fakela_est == true)
            {

                animator.SetBool("attack", false);  //------> ïåðåõîä íà CHASE
            }
            else
            {
                animator.transform.LookAt(enemy[blizh].transform);  //-----<<< Ñìîòðèò ÍÀ ÖÅËÜ

                //--------------ÂÊËÞ×ÈÒÜ ÍÀÂÌÅØ--ÎÁÒÝÉÊË
                agent.enabled = false;
                obtekat.enabled = true;

            }
                      
        }
           
    }

    


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fakela_est = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : StateMachineBehaviour
{
    GameObject NPC;
    GameObject[] waypoint;
    int currentWP;

    

    private void Awake()
    {
        waypoint = GameObject.FindGameObjectsWithTag("waypoint");
    }



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        
         NPC = animator.gameObject;
        currentWP = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoint.Length == 0) return;
        if (Vector3.Distance(waypoint[currentWP].transform.position,NPC.transform.position) < 3.0f)
        {
            currentWP++;
            if(currentWP >= waypoint.Length) 
            { 
                currentWP = 0;
            }
        }

        //rotate towards target

        var direction = waypoint[currentWP].transform.position - NPC.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction),1.0f * Time.deltaTime);
        NPC.transform.Translate(0, 0, Time.deltaTime * 2.0f);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}   

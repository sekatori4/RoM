using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    Vector3 target_kidat;
    Transform ruka_kidat;
    Rigidbody boolet;

    //--------------------------------------------------------------------------------------------------------------------------

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;

    }

    public void LaunchProjectale()
    {
        
        
        Vector3 Vo = CalculateVelocity(target_kidat, ruka_kidat.position, 1f);


        Rigidbody obj = Instantiate(boolet, ruka_kidat.position, Quaternion.AngleAxis(90, Vector3.forward));
        obj.velocity = Vo; 

    }
    //----------------------------------------------------------------------------------------------------------------------------------

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        animator.GetComponent<torch_throw_projectile>().KINUT();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        obtekat = animator.GetComponent<NavMeshObstacle>();                   //---<<<<<----------------   ��������
        agent = animator.GetComponent<NavMeshAgent>();
        castle = GameObject.FindGameObjectsWithTag("castle");
        deff = GameObject.FindGameObjectsWithTag("deff");
        ruka_kidat = animator.GetComponent<torch_throw_projectile>().pointshoot;
        boolet = animator.GetComponent<torch_throw_projectile>().torchPrefab;

        if (deff.Length > 0)

        {
            attackRange = 20;
            enemy = deff;
        }
        else
        {
            attackRange = 20;
            enemy = castle;
        }




        if (enemy.Length < 1)
        {
            animator.SetBool("atack", false);    // ������� ������� � �������� WALK � ������ � �������� ������!!!

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





            animator.transform.LookAt(enemy[blizh].transform);  //-----<<< ������� �� ����

            target_kidat = enemy[blizh].transform.position;
            
            



            //--------------�������� ������--�������
            agent.enabled = false;
            obtekat.enabled = true;


            //----------------------------------
            //-------------

            
            
            float distance = Vector3.Distance(animator.transform.position, enemy[blizh].transform.position);
            if (distance > attackRange)
            {
               animator.SetBool("attack", false);  //------> ������� �� CHASE
            }
        }
    }







    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}

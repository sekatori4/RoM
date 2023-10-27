using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class skelet_hp : MonoBehaviour
{
    public int MAX_HP = 100;
    public int curHP1;
    public Animator animator;

    [SerializeField] private Slider healthSlider;
    


    private void Start()
    {
        curHP1 = MAX_HP;
        healthSlider.maxValue = MAX_HP;
        healthSlider.maxValue = MAX_HP;
    
    }






    public void TakeDamage(int damage)
    {
        
        curHP1 -= damage;

        
        
        
        Debug.Log(damage);
        if ( curHP1<= 0)
        {
            //что делать при смерти
            
            
            NavMeshAgent.Destroy(animator);


            
            gameObject.transform.tag = "corpse";

            gameObject.GetComponentInChildren<Canvas>().enabled = false;

            
            Destroy(transform.gameObject, 4);



        }
        else
        {
            //играть эффект попадания
        }


    }


    private void OnGUI()
    {
        {
            
                  
            healthSlider.value = curHP1;

        }
    }






}
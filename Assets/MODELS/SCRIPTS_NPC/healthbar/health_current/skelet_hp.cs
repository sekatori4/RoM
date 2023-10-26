using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skelet_hp : MonoBehaviour
{
    public int MAX_HP = 100;
    public int curHP1 = 100;
    public Animator animator;
    
    
    
    public void TakeDamage(int damage)
    {
        
        curHP1 -= damage;
        Debug.Log(damage);
        if ( curHP1< 0)
        {
            //что делать при смерти
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            //играть эффект попадания
        }


    }
}
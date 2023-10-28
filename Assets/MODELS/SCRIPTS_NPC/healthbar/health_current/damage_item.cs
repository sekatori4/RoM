using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_item : MonoBehaviour
{

    public weapon_abstract wa;



    private void OnTriggerEnter (Collider other)
    {
        Debug.Log("OnTrigger---> "+other.tag);
       
        if (other.tag == "skelet")

        {
            Debug.Log("lox2");

            other.GetComponentInParent<skelet_hp>().TakeDamage(wa.damage);
            
        }
       


    }

}

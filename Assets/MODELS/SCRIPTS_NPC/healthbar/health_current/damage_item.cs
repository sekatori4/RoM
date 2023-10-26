using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_item : MonoBehaviour
{

    public weapon_abstract wa;



    private void OnTriggerEnter (Collider other)
    {
        Debug.Log("lox");
       
        if (other.tag == "skelet")

        {
            Debug.Log("lox2");

            other.GetComponent<skelet_hp>().TakeDamage(wa.damage);
            
        }


    }

}

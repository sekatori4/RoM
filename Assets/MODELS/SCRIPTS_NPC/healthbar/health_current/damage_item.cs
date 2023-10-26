using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_item : MonoBehaviour
{


    public int damageAmount = 20;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "skelet")

        {
            other.GetComponent<skelet_hp>().TakeDamage(damageAmount);

        }


    }

}

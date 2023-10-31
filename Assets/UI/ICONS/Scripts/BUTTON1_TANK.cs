using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BUTTON1_TANK : MonoBehaviour
{
    public GameObject spawner_init;
    
    
    
    // Start is called before the first frame update
    public void clicker()
    {
        GameObject Man_Weapon = GameObject.FindGameObjectWithTag("1boss");


        Debug.Log("TAAAAAAAAAAAAAAAAAAANK");
        GameObject MOBs;
       
        MOBs =Instantiate(spawner_init.GetComponent<SPAWNER>().NPC10, spawner_init.GetComponent<SPAWNER>().spawnPoint2);
        MOBs.GetComponentInChildren<damage_item>().wa = Man_Weapon.GetComponent<weapon_abstract>();
        MOBs.transform.parent = null;


    }

   
}

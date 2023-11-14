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
        
        Debug.Log("TAAAAAAAAAAAAAAAAAAANK");
        
        GameObject MOBs= Instantiate(spawner_init.GetComponent<SPAWNER>().NPC10, spawner_init.GetComponent<SPAWNER>().spawnPoint1.transform );
        

        MOBs.transform.parent = null;


    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BUTTON1_skelet : MonoBehaviour
{
    public GameObject spawner_init;
    
    
    
    // Start is called before the first frame update
    public void clicker()
    {

        Debug.Log("CLIIIIIIIIIIIICK");
        GameObject skeletik;
        skeletik =Instantiate(spawner_init.GetComponent<SPAWNER>().NPC1, spawner_init.GetComponent<SPAWNER>().spawnPoint1);
        
    }

   
}

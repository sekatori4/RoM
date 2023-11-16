using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BUTTON1_TANK : MonoBehaviour
{
    public GameObject spawner_init;
    public int cost_tank;
    
    
    // Start is called before the first frame update
    public void clicker()
    {
        
        Debug.Log("TAAAAAAAAAAAAAAAAAAANK");
        
        if (gameObject.GetComponentInParent <UI_Resources>().cur_souls >= cost_tank)
        {
            gameObject.GetComponentInParent<UI_Resources>().Getsouls(-cost_tank);

            GameObject MOBs = Instantiate(spawner_init.GetComponent<SPAWNER>().NPC10, spawner_init.GetComponent<SPAWNER>().spawnPoint1.transform);
            MOBs.transform.parent = null;

        }
                      
        

    }

   
}

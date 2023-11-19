using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel.Design;

public class BUTTON1_TANK : MonoBehaviour
{
    public GameObject spawner_init;
    public Button tank_init_visible;
    public int cost_tank_souls;
    public TextMeshProUGUI souls_cost_tank;
    public TextMeshProUGUI power_cost_tank;
    public GameObject UI_MAIN;
    Color standartcolor;

    // Start is called before the first frame update

    public void Start()
    {
        power_cost_tank.text = spawner_init.GetComponent<SPAWNER>().NPC10.GetComponent<crusader_death>().cost_power.ToString();
        souls_cost_tank.text = cost_tank_souls.ToString();
        standartcolor = tank_init_visible.GetComponent<Image>().color;
        
    }

    public void Update()
    {
        if (gameObject.GetComponentInParent<UI_Resources>().cur_souls < cost_tank_souls || 
            UI_MAIN.GetComponentInChildren <power_summons>().Curent_power < spawner_init.GetComponent<SPAWNER>().NPC10.GetComponent<crusader_death>().cost_power)
        {
            tank_init_visible.GetComponent<Image>().color = Color.gray ;
            tank_init_visible.GetComponent<Button>().enabled = false;
        }
        else
        {
            tank_init_visible.GetComponent<Image>().color = standartcolor;
            tank_init_visible.GetComponent<Button>().enabled = true;
        }

    }




    public void clicker()
    {
        
        Debug.Log("TAAAAAAAAAAAAAAAAAAANK");

        if (gameObject.GetComponentInParent<UI_Resources>().cur_souls >= cost_tank_souls && UI_MAIN.GetComponentInChildren<power_summons>().Curent_power >= spawner_init.GetComponent<SPAWNER>().NPC10.GetComponent<crusader_death>().cost_power) 
        {
            gameObject.GetComponentInParent<UI_Resources>().Getsouls(-cost_tank_souls);
            UI_MAIN.GetComponentInChildren<power_summons>().minus_power(spawner_init.GetComponent<SPAWNER>().NPC10.GetComponent<crusader_death>().cost_power);

            GameObject MOBs = Instantiate(spawner_init.GetComponent<SPAWNER>().NPC10, spawner_init.GetComponent<SPAWNER>().spawnPoint1.transform);
            MOBs.transform.parent = null;

        }
                      
        

    }

   
}

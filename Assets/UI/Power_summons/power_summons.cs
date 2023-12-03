using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class power_summons : MonoBehaviour
{
    public int Curent_power;
    public TextMeshProUGUI power_summon;
    public int count_skull;
      // Start is called before the first frame update
    void Start()
    {
        Curent_power = count_skull;  
        power_summon.text = count_skull.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        power_summon.text = Curent_power.ToString();
    }

    public void minus_power(int zatrata)
    {
        Curent_power -= zatrata;
                
    }
    public void popolnenie_power(int popolnenie)
    {
        Curent_power += popolnenie;

    }


}

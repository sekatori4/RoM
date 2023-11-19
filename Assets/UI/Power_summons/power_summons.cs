using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class power_summons : MonoBehaviour
{
    public int Curent_power;
    public TextMeshProUGUI power_summon;
    public TextMeshProUGUI exp_to_lvl;
    public int count_skull;
    public Slider sliderXP;
    public int currentXP = 0;
    // Start is called before the first frame update
    void Start()
    {
        exp_to_lvl.text = currentXP.ToString();
        sliderXP.maxValue = 100;
        sliderXP.value = 0;
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
        sliderXP.value += zatrata*10f;
        
        exp_to_lvl.text = sliderXP.value.ToString();
        
    }
    public void popolnenie_power(int popolnenie)
    {
        Curent_power += popolnenie;

    }


}

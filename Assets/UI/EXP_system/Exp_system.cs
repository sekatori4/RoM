using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Exp_system : MonoBehaviour
{
    public int curLVL = 1;
    public int curEXP = 0;
    public int expToLvlUp = 100;
    public int expIncFactor = 2;

    public Slider expSlider;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI curEXPText;
    public TextMeshProUGUI expToLVLText;
    
    // Update is called once per frame
    void Update()
    {
        UpdateUI(); 
    }

    private void GainEXPFromEnemy(int amountEXP)
    {
        GainEXP(amountEXP);
    }

    private void GainEXP(int amountEXP)
    {
        curEXP += amountEXP;

        while (curEXP >= expToLvlUp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        curLVL++;
        curEXP -= expToLvlUp;
        expToLvlUp *= expIncFactor;

    }
    private void UpdateUI()
    {
        //SLIDER UI
       if(expSlider != null)
        {
            expSlider.maxValue = expToLvlUp;
            expSlider.value = curEXP;
        } 
       //LevelTEXT
       if (Level.text != null)
        {
            Level.text = curLVL.ToString();
        }
        //CurrentXPTEXT
        if (curEXPText.text != null)
        {
            curEXPText.text = curEXP.ToString();
        }
        //CurrentXpToLVLTEXT
        if (expToLVLText.text != null)
        {
            expToLVLText.text = expToLvlUp.ToString();
        }


    }
}


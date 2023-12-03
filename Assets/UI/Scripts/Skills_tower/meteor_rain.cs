using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class meteor_rain : MonoBehaviour
{
    public Button selfbutton;
    private GameObject effect_to_dest;
    public GameObject meteor_rain_prefab;
    public Button knopka_dis;
    public float radius_damage = 10f;
    public float damage;
    public float kol_voln = 5f;
    float kol_voln_max;

    public Image abilityImage_cd;
    public Text abilityText_cd;
    public float abilityCooldown = 18;

    private bool isAbilityCooldown = false;

    private bool klik_cd = false;
    private float currentAbilityCooldown;
    
    // Start is called before the first frame update
    public void Start()
    {
        kol_voln_max = kol_voln;
        var mainPS = meteor_rain_prefab.GetComponent<ParticleSystem>().main;
        mainPS.duration = kol_voln;

        abilityImage_cd.fillAmount = 0;

        abilityText_cd.text = "";

    }

    public void Update()
    {
        AbilityInput();

        AbilityCooldown(ref currentAbilityCooldown, abilityCooldown, ref isAbilityCooldown, abilityImage_cd, abilityText_cd);

    }

    private void AbilityInput()
    {
        if (klik_cd == true && !isAbilityCooldown)
        {
            isAbilityCooldown=true;
            currentAbilityCooldown = abilityCooldown;
            klik_cd=false;
            
        }
    }

    private void AbilityCooldown(ref float currentCooldawn, float maxCooldown,ref bool isCooldown, Image skillImage, Text skillText)
    {
        if(isCooldown)
        {
            currentAbilityCooldown -= Time.deltaTime;

            if (currentCooldawn <= 0f) 
            {
                isCooldown = false;
                currentAbilityCooldown = 0f;
                selfbutton.enabled = true;

                if (skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if(skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                if(skillImage != null)
                {
                    skillImage.fillAmount = currentCooldawn / maxCooldown;
                }
                if (skillText != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldawn).ToString();
                }

            }

        }

    }


    public void click_rain()
    {
        klik_cd = true;     //--------------------кд скила

        selfbutton.enabled = false;

        kol_voln_max = kol_voln;

        effect_to_dest = Instantiate(meteor_rain_prefab, new Vector3 (0,0,0), Quaternion.identity);
        
        StartCoroutine(DOT_DPS());

       // Destroy(effect, kol_voln);
      //  knopka_dis.interactable = false;
        
    }

    private IEnumerator DOT_DPS()
    {
        while (kol_voln_max > 0)
        {
            
         Debug.Log(kol_voln_max);
         kol_voln_max--;
            
            
            Collider[] colliders = Physics.OverlapSphere(new Vector3(0, 0, 0), radius_damage);
            foreach (Collider nearbyObject in colliders)
            {
                if (nearbyObject.tag == "skelet")
                {
                   nearbyObject.GetComponentInParent<MAX_HP_OBSHEE>().TakeDamageMage(damage);
                }
            }
                yield return new WaitForSeconds(1f);
        }
        if (kol_voln_max == 0)
        {
            
            Destroy(effect_to_dest,3f);
        }
           

    }


}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class meteor_rain : MonoBehaviour
{
    public GameObject meteor_rain_prefab;
    public Button knopka_dis;
    public float radius_damage = 10f;
    public float damage;
    public float kol_voln = 5f;
    float kol_voln_max;
    
    // Start is called before the first frame update
    public void Start()
    {
        kol_voln_max = kol_voln;
    }

    public void Update()
    {
       
    }


    public void click_rain()
    {
        kol_voln_max = kol_voln;

        var effect = Instantiate(meteor_rain_prefab, new Vector3 (0,0,0), Quaternion.identity);
       
        StartCoroutine(DOT_DPS());

        Destroy(effect, 5f);
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
                yield return new WaitForSeconds(0.65f);
        }

    }


}

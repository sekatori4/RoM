using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class torch_throw_projectile : MonoBehaviour
{
    public Rigidbody torchPrefab;
    public GameObject fakel;
    public GameObject ogon;
    public Transform pointshoot;
    public Animator anim;
    
    
    
    public void KINUT()
    {
        fakel.gameObject.SetActive(true);
        StartCoroutine(vikinul(0.7f));

    }

    private IEnumerator vikinul(float value)
    {
        yield return new WaitForSeconds(value);
        fakel.gameObject.SetActive(false);

        anim.GetBehaviour<atack_torch>().LaunchProjectale();
        

    }





    public void reload_torch()
    {

        fakel.gameObject.SetActive(false);
        StartCoroutine(dostal_fakel(1f));


    }

    private IEnumerator dostal_fakel(float value)
    {
       yield return new WaitForSeconds(value);

       fakel.gameObject.SetActive(true);
       ogon.gameObject.SetActive(false);
       yield return new WaitForSeconds(0.5f);
       ogon.gameObject.SetActive(true);

    }

    

}
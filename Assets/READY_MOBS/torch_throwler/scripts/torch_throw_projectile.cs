using System.Collections;
using UnityEngine;



public class torch_throw_projectile : MonoBehaviour
{
    public GameObject torchPrefab;
    public GameObject fakel;
    public GameObject ogon;
    public GameObject pointshoot;
    public Animator anim;
    private Vector3 target; // GPT
    private Vector3 curtarget;
   
    public void SetTarget(Vector3 newTarget)
{
    target = newTarget;
}

    public void KINUT()
    {
        fakel.gameObject.SetActive(false);
        anim.GetBehaviour<atack_torch>().LaunchProjectale(anim);
    }

    
    public void DoCoroutine()
    {
        GameObject rocket = Instantiate(anim.GetBehaviour<atack_torch>().boolet, anim.GetBehaviour<atack_torch>().ruka_kidat.transform.position, anim.GetBehaviour<atack_torch>().boolet.transform.rotation);
              
        rocket.transform.LookAt(target);
        StartCoroutine(SendHoming(rocket));
        curtarget = target;
    }

   
    public IEnumerator SendHoming(GameObject rocket)
    {
         while (curtarget !=null && Vector3.Distance(target, rocket.transform.position)>0.3f)  
        {
           
            rocket.transform.position += (curtarget - rocket.transform.position).normalized * 15 * Time.deltaTime;

            //------------------------------------------------------кручение
            rocket.transform.rotation *= Quaternion.Euler(new Vector3(1f, 0, 0));

            //-----------------------------------------------------------------
                             

            yield return null;
         
        }
        
        

        Destroy(rocket,1f);

    }

    
    public void dostal_fakel()
    {
        fakel.gameObject.SetActive(true);
        ogon.gameObject.SetActive(false);
    }

    public void reload_torch()
    {
        ogon.gameObject.SetActive(true);
    }

    
}
using System.Collections;
using UnityEngine;



public class torch_throw_projectile : MonoBehaviour
{
    public GameObject torchPrefab;
    public GameObject fakel;
    public GameObject ogon;
    public GameObject pointshoot;
    public Animator anim;
    private GameObject target; // GPT

    public void KINUT()
    {
        fakel.gameObject.SetActive(false);
        anim.GetBehaviour<atack_torch>().LaunchProjectale(anim);
    }


    public void DoCoroutine(GameObject target)
    {
        this.target = target;
        GameObject rocket = Instantiate(anim.GetBehaviour<atack_torch>().boolet, anim.GetBehaviour<atack_torch>().ruka_kidat.transform.position, anim.GetBehaviour<atack_torch>().boolet.transform.rotation);

        rocket.transform.LookAt(target.GetComponentInChildren<Renderer>().bounds.center);
        StartCoroutine(SendHoming(rocket));
    }


    public IEnumerator SendHoming(GameObject rocket)
    {
        while (Vector3.Distance(target.GetComponentInChildren<Renderer>().bounds.center, rocket.transform.position) > 0.3f)
        {
            rocket.transform.position += (target.GetComponentInChildren<Renderer>().bounds.center - rocket.transform.position).normalized * 15 * Time.deltaTime;

            //------------------------------------------------------кручение
            rocket.transform.rotation *= Quaternion.Euler(new Vector3(1f, 0, 0));

            //-----------------------------------------------------------------

            yield return null;
        }

        Destroy(rocket, 1f);
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
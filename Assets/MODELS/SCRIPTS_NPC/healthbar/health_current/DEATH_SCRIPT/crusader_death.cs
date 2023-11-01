using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crusader_death : MonoBehaviour, IDeath
{
    [SerializeField] GameObject WEAPON;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void death_activate()
    {
        GetComponent<Animator>().SetBool("isdeath", true);

        //-------------Коллайдер ВЫКЛ ГЛАВНОМУ

        gameObject.GetComponent<BoxCollider>().enabled = false;


        //--------вЫключить коллайдер оружию


        WEAPON.GetComponent<BoxCollider>().enabled = false;




        //---------->>>  Я и все мои дети ТЭГИ--> ТРУПЫ



        Transform[] otherOB = GetComponentsInChildren<Transform>();

        foreach (Transform t in otherOB) { t.gameObject.tag = "corpse"; }

        //----------------------------------------------------------------------



        //----------ВЫКЛЮЧИТЬ ПОЛОСКУ ХП
        gameObject.GetComponentInChildren<Canvas>().enabled = false;
        //----------------------------------------------------------------------------------------------------------------------------------


        StartCoroutine(trup_erase(5f));
    }


    private IEnumerator trup_erase(float value)
    {


        // Do something before
        yield return new WaitForSeconds(value);

        //------------ уничтожить объект через 4 секи (меняется)        

        Destroy(transform.gameObject, 5);
    }

    private void Update()
    {
        
    }

    public void Move()
    {

    }


}


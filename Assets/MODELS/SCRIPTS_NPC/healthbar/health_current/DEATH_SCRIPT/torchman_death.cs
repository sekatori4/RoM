using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchman_death : MonoBehaviour, IDeath
{
    [SerializeField] GameObject WEAPON;
    public int get_souls;
    bool pidor;
    Camera camera_ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (pidor)
        {
            gameObject.transform.position += Vector3.down * Time.deltaTime * 1f;
        }
    }

    public void death_activate()
    {
        camera_ui = Camera.main;

        camera_ui.GetComponentInChildren<UI_Resources>().Getsouls(get_souls);
        //----------------------------------------------------------------------------------------------------------------------------------



        GetComponent<Animator>().SetInteger("deadRANDOM", Random.Range(0,3));
        
        GetComponent<Animator>().SetBool("isdead", true);

        //-------------Коллайдер ВЫКЛ ГЛАВНОМУ

        gameObject.GetComponent<BoxCollider>().enabled = false;


        //--------вЫключить коллайдер оружию


        //WEAPON.GetComponent<BoxCollider>().enabled = false;

        //---------->>>  Я и все мои дети ТЭГИ--> ТРУПЫ

        Transform[] otherOB = GetComponentsInChildren<Transform>();

        foreach (Transform t in otherOB) { t.gameObject.tag = "corpse"; }

        //----------------------------------------------------------------------

        //----------ВЫКЛЮЧИТЬ ПОЛОСКУ ХП
        gameObject.GetComponentInChildren<Canvas>().enabled = false;
        //----------------------------------------------------------------------------------------------------------------------------------

        StartCoroutine(trup_erase(3f));
    }


    private IEnumerator trup_erase(float value)
    {


        // Do something before
        yield return new WaitForSeconds(value);

        pidor = true;




        //------------ уничтожить объект через 4 секи (меняется)        

        Destroy(transform.gameObject, 4f);
    }

    
    

    public void Move()
    {

    }


}


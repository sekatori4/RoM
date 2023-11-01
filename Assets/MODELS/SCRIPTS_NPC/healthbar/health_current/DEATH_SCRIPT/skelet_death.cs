using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skelet_death : MonoBehaviour, IDeath
{
    public Animator animator;
    bool pidor;
    
    




    public void death_activate()
    {
        //что делать при смерти

        //---------Выключить аниматор

        GetComponent<Animator>().enabled = false;



        //---------->>>  РИГИБОДИ ВКЛ ВСЕМ

        Rigidbody[] rigidON = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody t in rigidON) { t.isKinematic = false; }

        //----------------------------------------------------------------------

        //---------->>>  РИГИБОДИ ВЫКЛ главному

        GetComponent<Rigidbody>().isKinematic = true;

        //----------------------------------------------------------------------


        //-----Коллайдер ВЫКЛ ОСНОВНОМУ (ФИКСАЦИЯ ПОЛУЧЕНИЯ УРОНА)
        gameObject.GetComponent<BoxCollider>().enabled = false;

        //-------------------------


        //------------Коллайдеры ВКЛ ВСЕМ
        Collider[] colON = GetComponentsInChildren<Collider>();

        foreach (Collider t in colON) { t.enabled = true; }

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


        private IEnumerator trup_erase(float value)
        {





            // Do something before
            yield return new WaitForSeconds(value);


            //------------------------>>>> Ригибоди ВЫКЛ всем
            Rigidbody[] rigidON = GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody t in rigidON) { t.isKinematic = true; }






            Collider[] coloff = GetComponentsInChildren<Collider>();

            foreach (Collider t in coloff) { t.enabled = false; }


            // ---------------->>>> погружение под землю

            pidor = true;


            //------------ уничтожить объект через 4 секи (меняется)        

            Destroy(transform.gameObject, 5);
            //-------------------------->>>> появление КОСТЕЙ

            GameObject clone_corpse = Instantiate(skelet_poivlenie, transform.position, transform.rotation);


            clone_corpse.SetActive(true);
            //-----------------------------

        }













    }

   

    
}


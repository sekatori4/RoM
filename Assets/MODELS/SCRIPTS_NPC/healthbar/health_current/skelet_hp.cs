using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Net.Http.Headers;



//       using UnityEngine.UIElements;

public class skelet_hp : MonoBehaviour
{
    public int MAX_HP = 100;
    public int curHP1;
    public Animator animator;
    bool pidor;

    public GameObject skelet_poivlenie;

    [SerializeField] private Slider healthSlider;






    public void Start()
    {
       
        
        
        curHP1 = MAX_HP;
        healthSlider.maxValue = MAX_HP;
        healthSlider.maxValue = MAX_HP;


        //----------РИГИБОДИ ДОЧЕРНИЕ ВЫКЛ

        Rigidbody[] rigid = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody t in rigid) { t.isKinematic = true; }

        //-------------------------



        //--------- Коллайдеры ДОЧЕРНИЕ ВЫКЛ

        Collider[] colOFF = GetComponentsInChildren<Collider>();

        foreach (Collider t in colOFF) { t.enabled = false; }

        //-----Коллайдер ВКЛ ОСНОВНОМУ (ФИКСАЦИЯ ПОЛУЧЕНИЯ УРОНА)
        gameObject.GetComponent<BoxCollider>().enabled = true;



    }


    private void Update()
    {
        

        if (pidor)
        {
            gameObject.transform.position += Vector3.down * Time.deltaTime * 1f;
        }


    }






    public void  TakeDamage(int damage)
    {
        
        curHP1 -= damage;

        
        
        
        Debug.Log(damage);
        if ( curHP1<= 0)
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



            //---------->>>  Я и все мои дети ТЭГИ--> ТРУПЫ



            Transform[] otherOB = GetComponentsInChildren<Transform>();

            foreach (Transform t in otherOB) { t.gameObject.tag = "corpse"; }

           //----------------------------------------------------------------------

    

            //----------ВЫКЛЮЧИТЬ ПОЛОСКУ ХП
             gameObject.GetComponentInChildren<Canvas>().enabled = false;
            //----------------------------------------------------------------------------------------------------------------------------------



            StartCoroutine(trup_erase(5f));
           
        }
       
        
        else
        {
            //играть эффект попадания
        }


    }


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

        GameObject clone_corpse  =  Instantiate(skelet_poivlenie, transform.position, transform.rotation);
        clone_corpse.SetActive(true);
        //-----------------------------

    }






    private void OnGUI()
    {
        {
            
                  
            healthSlider.value = curHP1;

        }
    }






}
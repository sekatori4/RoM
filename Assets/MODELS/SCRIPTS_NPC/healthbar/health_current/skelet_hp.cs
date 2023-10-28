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


        //----------�������� �������� ����

        Rigidbody[] rigid = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody t in rigid) { t.isKinematic = true; }

        //-------------------------



        //--------- ���������� �������� ����

        Collider[] colOFF = GetComponentsInChildren<Collider>();

        foreach (Collider t in colOFF) { t.enabled = false; }

        //-----��������� ��� ��������� (�������� ��������� �����)
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
            //��� ������ ��� ������
            
            //---------��������� ��������
            
           GetComponent<Animator>().enabled = false;



            //---------->>>  �������� ��� ����

            Rigidbody[] rigidON = GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody t in rigidON) { t.isKinematic = false; }

            //----------------------------------------------------------------------

            //---------->>>  �������� ���� ��������

            GetComponent<Rigidbody>().isKinematic = true;

            //----------------------------------------------------------------------


            //-----��������� ���� ��������� (�������� ��������� �����)
            gameObject.GetComponent<BoxCollider>().enabled = false;

            //-------------------------


            //------------���������� ��� ����
            Collider[] colON = GetComponentsInChildren<Collider>();

            foreach (Collider t in colON) { t.enabled = true; }

            //-------------��������� ���� ��������

            gameObject.GetComponent<BoxCollider>().enabled = false;



            //---------->>>  � � ��� ��� ���� ����--> �����



            Transform[] otherOB = GetComponentsInChildren<Transform>();

            foreach (Transform t in otherOB) { t.gameObject.tag = "corpse"; }

           //----------------------------------------------------------------------

    

            //----------��������� ������� ��
             gameObject.GetComponentInChildren<Canvas>().enabled = false;
            //----------------------------------------------------------------------------------------------------------------------------------



            StartCoroutine(trup_erase(5f));
           
        }
       
        
        else
        {
            //������ ������ ���������
        }


    }


    private IEnumerator trup_erase(float value)
    {

        



        // Do something before
        yield return new WaitForSeconds(value);


        //------------------------>>>> �������� ���� ����
        Rigidbody[] rigidON = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody t in rigidON) { t.isKinematic = true; }






        Collider[] coloff = GetComponentsInChildren<Collider>();

        foreach (Collider t in coloff) { t.enabled = false; }


        // ---------------->>>> ���������� ��� �����


        pidor = true;
        



        //------------ ���������� ������ ����� 4 ���� (��������)        

        Destroy(transform.gameObject, 5);
        //-------------------------->>>> ��������� ������

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
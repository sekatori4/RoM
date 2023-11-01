using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skelet_death : MonoBehaviour, IDeath
{
    public Animator animator;
    bool pidor;
    
    




    public void death_activate()
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


        //--------��������� ��������� ������


        WEAPON.GetComponent<BoxCollider>().enabled = false;




        //---------->>>  � � ��� ��� ���� ����--> �����



        Transform[] otherOB = GetComponentsInChildren<Transform>();

        foreach (Transform t in otherOB) { t.gameObject.tag = "corpse"; }

        //----------------------------------------------------------------------



        //----------��������� ������� ��
        gameObject.GetComponentInChildren<Canvas>().enabled = false;
        //----------------------------------------------------------------------------------------------------------------------------------



        StartCoroutine(trup_erase(5f));


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

            GameObject clone_corpse = Instantiate(skelet_poivlenie, transform.position, transform.rotation);


            clone_corpse.SetActive(true);
            //-----------------------------

        }













    }

   

    
}


using System.Collections;
using UnityEngine;

public class skelet_death : MonoBehaviour, IDeath
{
    [SerializeField] GameObject WEAPON;
    [SerializeField] GameObject ostanki;
    public int get_souls;
    bool pidor;
    Camera camera_ui;
   
   

    private void Update()
    {
        if (pidor)
        {
            gameObject.transform.position += Vector3.down * Time.deltaTime * 1f;
        }
    }

    public void death_activate()
    {
        //��� ������ ��� ������

        //----------------------------------------->> �������� ����
        camera_ui = Camera.main;

        camera_ui.GetComponentInChildren<UI_Resources>().Getsouls(get_souls);
        //----------------------------------------------------------------------------------------------------------------------------------





        //---------��������� ��������
        GetComponent<Animator>().enabled = false;



        //---------->>>  �������� ��� ����

        Rigidbody[] rigidON = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody t in rigidON) { t.isKinematic = false; }

        //----------------------------------------------------------------------

        //---------->>>  �������� ���� ��������

        GetComponent<Rigidbody>().isKinematic = true;

        //----------------------------------------------------------------------

              
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
    }



    private IEnumerator trup_erase(float value)
    {
        // Do something before
        yield return new WaitForSeconds(value);


        //------------------------>>>> �������� ���� ����
        Rigidbody[] rigidON = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody t in rigidON) { t.isKinematic = true; }

       //------------------------>>> ���������� ��������� ����
        Collider[] coloff = GetComponentsInChildren<Collider>();

        foreach (Collider t in coloff) { t.enabled = false; }


        // ---------------->>>> ���������� ��� �����

        pidor = true;

        //------------ ���������� ������ ����� 4 ���� (��������)        

        Destroy(transform.gameObject, 5);
        //-------------------------->>>> ��������� ������

        GameObject clone_corpse = Instantiate(ostanki, transform.position, transform.rotation);


        clone_corpse.SetActive(true);
        //-----------------------------

        
    
    
    
    
    }
}

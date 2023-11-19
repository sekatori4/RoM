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

        //-------------��������� ���� ��������

        gameObject.GetComponent<BoxCollider>().enabled = false;


        //--------��������� ��������� ������


        //WEAPON.GetComponent<BoxCollider>().enabled = false;

        //---------->>>  � � ��� ��� ���� ����--> �����

        Transform[] otherOB = GetComponentsInChildren<Transform>();

        foreach (Transform t in otherOB) { t.gameObject.tag = "corpse"; }

        //----------------------------------------------------------------------

        //----------��������� ������� ��
        gameObject.GetComponentInChildren<Canvas>().enabled = false;
        //----------------------------------------------------------------------------------------------------------------------------------

        StartCoroutine(trup_erase(3f));
    }


    private IEnumerator trup_erase(float value)
    {


        // Do something before
        yield return new WaitForSeconds(value);

        pidor = true;




        //------------ ���������� ������ ����� 4 ���� (��������)        

        Destroy(transform.gameObject, 4f);
    }

    
    

    public void Move()
    {

    }


}


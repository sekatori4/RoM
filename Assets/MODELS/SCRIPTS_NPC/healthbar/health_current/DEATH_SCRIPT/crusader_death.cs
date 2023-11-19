using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class crusader_death : MonoBehaviour, IDeath
{
    [SerializeField] GameObject WEAPON;
    public int cost_power;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void death_activate()
    {
        
        Camera.main.GetComponentInChildren<power_summons>().popolnenie_power(cost_power);


        GetComponent<Animator>().SetBool("isdeath", true);

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


        StartCoroutine(trup_erase(3f));
    }


    private IEnumerator trup_erase(float value)
    {


        // Do something before
        yield return new WaitForSeconds(value);

        //------------ ���������� ������ ����� 4 ���� (��������)        

        Destroy(transform.gameObject, 5);
    }

    private void Update()
    {
        
    }

    public void Move()
    {

    }


}


using OpenCover.Framework.Model;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;




//       using UnityEngine.UIElements;

public class MAX_HP_OBSHEE : MonoBehaviour
{
    public float MAX_HP;
    public float curHP;
    [SerializeField] public float physic_ARMOR_percent;
    [SerializeField] public float mage_ARMOR_percent;
    public UnityEngine.Object script_smerti;
    public UnityEngine.Object script_smerti;
    



    [SerializeField] private Slider healthSlider;   // ������� ��
    
    [SerializeField] GameObject WEAPON;           // ��������� ������  --------------->>>>>>>>>>>>>>>>>>>>> ��������





    public void Start()
    {



        curHP = MAX_HP;
        healthSlider.maxValue = MAX_HP;

        

        //----------��������  ���� ���

        Rigidbody[] rigid = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody t in rigid) { t.isKinematic = true; }

        //-------------------------



        //--------- ���������� ��� ����

        Collider[] colOFF = GetComponentsInChildren<Collider>();

        foreach (Collider t in colOFF) { t.enabled = false; }

        //-----��������� ��� ��������� (�������� ��������� �����)
        gameObject.GetComponent<BoxCollider>().enabled = true;

        //--------�������� ��������� ������

        WEAPON.GetComponent<BoxCollider>().enabled = true;




    }

       


    public void TakeDamagePhys(float damage)
    {
        curHP = curHP - (damage - ((damage / 100) * physic_ARMOR_percent));

       
               

        if (curHP <= 0)
        {
            //��� ������ ��� ������

            //---------��������� ��������

            
            
            

        }   

       


    }

    public void TakeDamageMage(float damage)
    {
        
        curHP = curHP - (damage - ((damage / 100) * mage_ARMOR_percent));



        if (curHP <= 0)
        {
            //��� ������ ��� ������

            


           



        }




    }





    private void OnGUI()
    {
        {


            healthSlider.value = curHP;

        }
    }






}
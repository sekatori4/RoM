using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;

public class laser_damage_item : MonoBehaviour
{
    [SerializeField] public string friend1;
    [SerializeField] public string friend2;
    [SerializeField] public string friend3;
    [SerializeField] public string friend4;
    [SerializeField] public string friend5;



    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip ZVUK_ORUZHIYA;
    [SerializeField] private GameObject effect_popadania;

    [SerializeField] public float physic_damage;
    [SerializeField] public float mage_damage;



    



    private void OnTriggerEnter(Collider other)
    {

        string SELF = transform.root.gameObject.tag;


        string vrag = other.transform.root.gameObject.tag;               // ������ ��� �������� ������� �� ���������� �� �������� ������ ������ ;


        if ( vrag != SELF                                            // ���� ������ ������ �� �� ������ ���������� � �� �� ���������� ���������
            &&vrag != friend1 
            && vrag != friend2 
            && vrag != friend3
            && vrag != friend4
            && vrag != friend5)
                {



            if (other.tag != "corpse" && other.tag != "floor")
            {
                Debug.Log(other.tag);
                other.GetComponentInParent<MAX_HP_OBSHEE>().TakeDamagePhys(physic_damage);
                other.GetComponentInParent<MAX_HP_OBSHEE>().TakeDamageMage(mage_damage);
                gameObject.GetComponent<BoxCollider>().enabled = false;
               // Destroy(gameObject, 1f);
                Explode();
                
            }


            
        }
       
    }


    void Explode()

    {

        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.forward, out hit))
        //{
        //    Debug.Log("Point of contact: " + hit.point);
        //}
        //------------------����� � ����� ��������������� ������� ���

        soundSource.PlayOneShot(ZVUK_ORUZHIYA);  
             if (effect_popadania != null)    //--------------�������� �� ������ �� ���� ������� ���������.
             {
              var effect = Instantiate(effect_popadania, transform.position, Quaternion.identity); //��������� ��������� ���������� ������� �� ��� �����, ���� ������ ����.
             }
        
       // Destroy(anim.GetBehaviour<atack_torch>().obj_torch, 0f);
    }


    public class manager
    {
    }
}

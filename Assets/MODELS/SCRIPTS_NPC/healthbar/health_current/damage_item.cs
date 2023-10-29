using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_item : MonoBehaviour
{

    [SerializeField] public string enemy_tag;
    
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip hitSkelet;
    public weapon_abstract wa;
    public GameObject effect_popadania;


    private void OnTriggerEnter (Collider other)
    {
        Debug.Log("OnTrigger---> "+other.tag);

        






        if (other.tag == enemy_tag)

        {





            //---------------------->>>> ����� ��������������� � �����������


            //RaycastHit hit;
            //if (Physics.Raycast(transform.position, transform.forward, out hit))
            //{
            //    Debug.Log("Point of contact: " + hit.point);
            //}
            ////------------------����� � ����� ��������������� ������� ���


            //GameObject HIT_obj = Instantiate(effect_popadania, hit.point, transform.rotation);


            Explode();



            other.GetComponentInParent<skelet_hp>().TakeDamage(wa.damage);

            



        }
       

        void Explode()

        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log("Point of contact: " + hit.point);
            }
            //------------------����� � ����� ��������������� ������� ���

            soundSource.PlayOneShot(hitSkelet);




            var effect = Instantiate(effect_popadania, transform.position, Quaternion.identity); //��������� ��������� ���������� ������� �� ��� �����, ���� ������ ����.
            


        }


    }

}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;

public class damage_item : MonoBehaviour
{

    [SerializeField] public string enemy_tag;
    [SerializeField] public string enemy_tag2;

    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip hitVRAG;
    

    [SerializeField] public weapon_abstract wa;

    
   

    public GameObject effect_popadania;

    

    private void OnTriggerEnter (Collider other)
    {
        
        string SELF = transform.root.gameObject.tag;


        string vrag = other.transform.root.gameObject.tag;               // выбран объект по КОЛЛАЙДЕРУ прикосновения оружия ;


        if (vrag != SELF)
        {
            if (vrag == "deff")
            {
                Explode();

                other.GetComponentInParent<HP_Death_no_rigi>().TakeDamage(wa.damage);
            }
            else
            {

                if (vrag == "skelet")

                {
                    Explode();

                    other.GetComponentInParent<skelet_hp>().TakeDamage(wa.damage);

                }

            }



        }






        //if (vrag.tag == "deff" && other.transform.root != transform.root )

        //{
        //    Debug.Log("OnTrigger---> " + other.tag);


        //    Explode();

           
        //    vrag.GetComponentInParent<HP_Death_no_rigi>().TakeDamage(wa.damage);
        //}
        //else


        //if (vrag.tag == "skelet" && other.transform.root != transform.root)
        //{
        //    Debug.Log("OnTrigger---> " + other.tag);
        //    vrag.GetComponentInParent<skelet_hp>().TakeDamage(wa.damage);

        //    Explode();
        //}

        //else


        //if (vrag.tag == "castle" && other.transform.root != transform.root )
        //{
        //    Debug.Log("OnTrigger---> " + other.tag);
        //    vrag.GetComponentInParent<castle_hp>().TakeDamage(wa.damage);

        //    Explode();
        //}

       





    }
       

        void Explode()

        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log("Point of contact: " + hit.point);
            }
            //------------------вызов в точке соприкосновения префаба ХИТ

            soundSource.PlayOneShot(hitVRAG);




            var effect = Instantiate(effect_popadania, transform.position, Quaternion.identity); //Создается экземпляр созданного префаба на том месте, куда попала пуля.
            


        }


    

    public class manager
    {
    }
}

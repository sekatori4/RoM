using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;

public class damage_item_TORCH : MonoBehaviour
{
    [SerializeField] public string friend1;
    [SerializeField] public string friend2;
    [SerializeField] public string friend3;
    [SerializeField] public string friend4;
    [SerializeField] public string friend5;



    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip ZVUK_ORUZHIYA;


    [SerializeField] public float physic_damage;
    [SerializeField] public float mage_damage;



    public GameObject effect_popadania;



    private void OnTriggerEnter(Collider other)
    {

        string SELF = transform.root.gameObject.tag;


        string vrag = other.transform.root.gameObject.tag;               // выбран ТЭГ ГЛАВНОГО объекта по КОЛЛАЙДЕРУ по которому попало оружие ;


        if (vrag != SELF                                              // Если попало оружие не по своему КОЛЛАЙДЕРУ и не по КОЛЛАЙДЕРУ СОЮЗНИКОВ
            && vrag != friend1 
            && vrag != friend2 
            && vrag != friend3
            && vrag != friend4
            && vrag != friend5)
                {



            if (other.tag != "corpse" && other.tag != "floor")
            {
                other.GetComponentInParent<MAX_HP_OBSHEE>().TakeDamagePhys(physic_damage);
                other.GetComponentInParent<MAX_HP_OBSHEE>().TakeDamageMage(mage_damage);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                Destroy(gameObject, 2f);
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
        //------------------вызов в точке соприкосновения префаба ХИТ

        soundSource.PlayOneShot(ZVUK_ORUZHIYA);

        var effect = Instantiate(effect_popadania, transform.position, Quaternion.identity); //Создается экземпляр созданного префаба на том месте, куда попала пуля.

        
       // Destroy(anim.GetBehaviour<atack_torch>().obj_torch, 0f);
    }


    public class manager
    {
    }
}

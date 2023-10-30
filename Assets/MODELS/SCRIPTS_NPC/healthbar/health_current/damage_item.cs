using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_item : MonoBehaviour
{

    [SerializeField] public string enemy_tag;
    
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip hitSkelet;

   
    [SerializeField] public weapon_abstract wa;

    


    public GameObject effect_popadania;


    private void OnTriggerEnter (Collider other)
    {
        Debug.Log("OnTrigger---> "+other.tag);


        



        if (other.tag == enemy_tag)

        {





            //---------------------->>>> точка соприкосновения с коллайдером


            //RaycastHit hit;
            //if (Physics.Raycast(transform.position, transform.forward, out hit))
            //{
            //    Debug.Log("Point of contact: " + hit.point);
            //}
            ////------------------вызов в точке соприкосновения префаба ХИТ


            //GameObject HIT_obj = Instantiate(effect_popadania, hit.point, transform.rotation);


            Explode();

            HP_Death_no_rigi enemy1 = other.GetComponentInParent<HP_Death_no_rigi>();

            if (enemy1 != null)
            {
                
                
                enemy1.TakeDamage(wa.damage);

            }
            else
            {
                other.GetComponentInParent<skelet_hp>().TakeDamage(wa.damage);

            }
           




        }
       

        void Explode()

        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log("Point of contact: " + hit.point);
            }
            //------------------вызов в точке соприкосновения префаба ХИТ

            soundSource.PlayOneShot(hitSkelet);




            var effect = Instantiate(effect_popadania, transform.position, Quaternion.identity); //Создается экземпляр созданного префаба на том месте, куда попала пуля.
            


        }


    }

    public class manager
    {
    }
}

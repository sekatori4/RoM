using System.Collections;
using UnityEngine;
using UnityEngine.UI;




//       using UnityEngine.UIElements;

public class HP_Death_no_rigi : MonoBehaviour
{
    public int MAX_HP = 100;
    public int curHP1;
    public Animator animator;
    
    public GameObject skelet_poivlenie;

    [SerializeField] private Slider healthSlider;
    [SerializeField] GameObject WEAPON;





    public void Start()
    {

        gameObject.GetComponent<BoxCollider>().enabled = true;  // ВКЛ коллайдер ОСНОВНОЙ
        WEAPON.GetComponent<BoxCollider>().enabled = true;    // ВКЛ КОЛЛАЙДЕР ОРУЖИЮ


        curHP1 = MAX_HP;
        healthSlider.maxValue = MAX_HP;
        healthSlider.maxValue = MAX_HP;




    }


    private void Update()
    {
        



    }






    public void  TakeDamage(int damage)
    {
        
        curHP1 -= damage;

                
        
        Debug.Log(damage);
       
        
        if ( curHP1<= 0)
        {                                    //------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>ССЫЛКА----->>>

            animator.SetBool("isdeath", true);

            //-------------Коллайдер ВЫКЛ ГЛАВНОМУ

            gameObject.GetComponent<BoxCollider>().enabled = false;


            //--------вЫключить коллайдер оружию


            WEAPON.GetComponent<BoxCollider>().enabled = false;




            //---------->>>  Я и все мои дети ТЭГИ--> ТРУПЫ



            Transform[] otherOB = GetComponentsInChildren<Transform>();

            foreach (Transform t in otherOB) { t.gameObject.tag = "corpse"; }

           //----------------------------------------------------------------------

    

            //----------ВЫКЛЮЧИТЬ ПОЛОСКУ ХП
             gameObject.GetComponentInChildren<Canvas>().enabled = false;
            //----------------------------------------------------------------------------------------------------------------------------------



            StartCoroutine(trup_erase(5f));
           
        }
               
        else
        {
            //играть эффект попадания
        }


    }


    private IEnumerator trup_erase(float value)
    {

        
        // Do something before
        yield return new WaitForSeconds(value);


        


        //------------ уничтожить объект через 4 секи (меняется)        

        Destroy(transform.gameObject, 5);
        

       

    }






    private void OnGUI()
    {
        {
            
                  
            healthSlider.value = curHP1;

        }
    }






}
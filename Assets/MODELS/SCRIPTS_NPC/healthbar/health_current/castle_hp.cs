using System.Collections;
using UnityEngine;
using UnityEngine.UI;




//       using UnityEngine.UIElements;

public class castle_hp : MonoBehaviour
{
    public int MAX_HP = 100;
    public int curHP1;
    public Animator animator;
    
    public GameObject skelet_poivlenie;

    [SerializeField] private Slider healthSlider;
    [SerializeField] GameObject WEAPON;





    public void Start()
    {
       
        
        
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
        {

           // animator.SetBool("isdeath", true);

            //-------------��������� ���� ��������

            gameObject.GetComponent<Collider>().enabled = false;


            //--------��������� ��������� ������


           // WEAPON.GetComponent<BoxCollider>().enabled = false;




            //---------->>>  � � ��� ��� ���� ����--> �����



            Transform[] otherOB = GetComponentsInChildren<Transform>();

            foreach (Transform t in otherOB) { t.gameObject.tag = "corpse"; }

           //----------------------------------------------------------------------

    

            //----------��������� ������� ��
             gameObject.GetComponentInChildren<Canvas>().enabled = false;
            //----------------------------------------------------------------------------------------------------------------------------------



            StartCoroutine(trup_erase(5f));
           
        }
               
        else
        {
            //������ ������ ���������
        }


    }


    private IEnumerator trup_erase(float value)
    {

        
        // Do something before
        yield return new WaitForSeconds(value);


        //------------ ���������� ������ ����� 4 ���� (��������)        

        Destroy(transform.gameObject, 5);
        

       

    }






    private void OnGUI()
    {
        {
            
                  
            healthSlider.value = curHP1;

        }
    }






}
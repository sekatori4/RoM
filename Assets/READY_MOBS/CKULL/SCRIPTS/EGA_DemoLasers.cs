using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class EGA_DemoLasers : MonoBehaviour
{
    public GameObject FirePoint;
    public Camera Cam;
    public float MaxLength;
    public GameObject[] Prefabs;

    private Ray RayMouse;
    private Vector3 direction;
    private Quaternion rotation;

    [Header("GUI")]
    private float windowDpi;

    GameObject[] enemy;
    GameObject enemy_blizh;
    public GameObject pointshoot;
    public GameObject boolet_laser;
    private int Prefab;
    private GameObject Instance;
    private EGA_Laser LaserScript;

    
    
    
    //Double-click protection
    private float CoolDawn = 0f;

    void Start ()
    {
       Counter(7);
    }

    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("skelet");

        

        int blizh = 0;
        for (int i = 0; i < enemy.Length; i++)
        {

            if (Vector3.Distance(enemy[i].transform.position, gameObject.transform.position) < Vector3.Distance(enemy[blizh].transform.position, gameObject.transform.position))
            {

                blizh = i;
            }
        }

        

        gameObject.transform.LookAt(enemy[blizh].transform.position + new Vector3 (0,2,0));
        enemy_blizh = enemy[blizh];

        CoolDawn += Time.deltaTime;

        if (Vector3.Distance(enemy[blizh].transform.position,gameObject.transform.position) < MaxLength  && CoolDawn >=0.8f)

        {
                  
            
            Debug.Log("DOSTAL" + MaxLength);
            
         
            Instance = Instantiate(Prefabs[Prefab], FirePoint.transform.position, FirePoint.transform.rotation);
            Instance.transform.parent = transform;
            LaserScript = Instance.GetComponent<EGA_Laser>();
           
            Destroy(Instance,0.7f);
            CoolDawn = 0f;


            GameObject rocket = Instantiate(boolet_laser, pointshoot.transform.position, pointshoot.transform.rotation);
            rocket.transform.LookAt(enemy[blizh].transform.position);   //---------смотреть на цель прямо ( нверное по ИКСУ)

            StartCoroutine(SendHoming(rocket));

        }
        
                     
        
        
    }

    public IEnumerator SendHoming(GameObject rocket)
    {
        while (Vector3.Distance(enemy_blizh.transform.position,rocket.transform.position) > 0.01f)

        {
            rocket.transform.position +=
                (enemy_blizh.transform.position - rocket.transform.position).normalized * 500 * Time.deltaTime;
                                
                  

            yield return null;

        }

        Destroy(rocket);

    }





    //To change prefabs (count - prefab number)
    void Counter(int count)
    {
        Prefab += count;
        if (Prefab > Prefabs.Length - 1)
        {
            Prefab = 0;
        }
        else if (Prefab < 0)
        {
            Prefab = Prefabs.Length - 1;
        }
    }
  
    //To rotate fire point
    //void RotateToMouseDirection (GameObject obj, Vector3 destination)
    //{
    //    direction = destination - obj.transform.position;
    //    rotation = Quaternion.LookRotation(direction);     
    //    obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    //}
}

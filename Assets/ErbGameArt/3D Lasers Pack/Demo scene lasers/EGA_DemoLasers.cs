using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;

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


    private int Prefab;
    private GameObject Instance;
    private EGA_Laser LaserScript;

    //Double-click protection
    private float buttonSaver = 0f;

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









        //Enable lazer
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(Instance);
            Instance = Instantiate(Prefabs[Prefab], FirePoint.transform.position, FirePoint.transform.rotation);
            Instance.transform.parent = transform;
            LaserScript = Instance.GetComponent<EGA_Laser>();
        }

        //Disable lazer prefab
        if (Input.GetMouseButtonUp(0))
        {
            LaserScript.DisablePrepare();
            Destroy(Instance,1);
        }

        //To change lazers
        if ((Input.GetKey(KeyCode.K) || Input.GetAxis("Horizontal") < 0) && buttonSaver >= 0.4f)// left button
        {
            buttonSaver = 0f;
            Counter(-1);
        }
        if ((Input.GetKey(KeyCode.L) || Input.GetAxis("Horizontal") > 0) && buttonSaver >= 0.4f)// right button
        {
            buttonSaver = 0f;
            Counter(+1);         
        }
        buttonSaver += Time.deltaTime;
        

        //Current fire point
        if (Cam != null)
        {
            RaycastHit hit; 
            var mousePos = Input.mousePosition;
            RayMouse = Cam.ScreenPointToRay(mousePos);
            
            if (Physics.Raycast(RayMouse.origin, RayMouse.direction, out hit, MaxLength)) 
            {
                RotateToMouseDirection(gameObject, hit.point);
                //LaserEndPoint = hit.point;
            }
            else
            {
                var pos = RayMouse.GetPoint(MaxLength);
                RotateToMouseDirection(gameObject, pos);
                //LaserEndPoint = pos;
            }
        }
        else
        {
            Debug.Log("No camera");
        }
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
    void RotateToMouseDirection (GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);     
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
}

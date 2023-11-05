using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
public class torch_throw_projectile : MonoBehaviour
{
    public Rigidbody torchPrefab;
    public GameObject fakel;
    public GameObject ogon;
    public Transform pointshoot;
    public Animator anim;


    public void KINUT()
    {
        fakel.gameObject.SetActive(false);
        anim.GetBehaviour<atack_torch>().LaunchProjectale();
    }



    public void dostal_fakel()
    {
        fakel.gameObject.SetActive(true);
        ogon.gameObject.SetActive(false);
    }

    public void reload_torch()
    {
        ogon.gameObject.SetActive(true);
    }

    
}
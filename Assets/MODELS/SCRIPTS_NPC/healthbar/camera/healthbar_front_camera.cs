using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar_front_camera : MonoBehaviour
{
    public Transform cam;
    
    
    void LateUpdate()
    {
        transform.LookAt(cam.position);
    }
}

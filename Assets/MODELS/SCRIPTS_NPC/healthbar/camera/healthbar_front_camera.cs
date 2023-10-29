using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar_front_camera : MonoBehaviour
{
    
    
    
    private void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
        
    }
}

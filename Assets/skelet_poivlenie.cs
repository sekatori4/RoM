using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class skelet_poivlenie : MonoBehaviour
{

    public Vector3 fromPosition;
    public Vector3 toPosition;
  
    private float progress;    

    private void Start()
    {
        fromPosition = new Vector3(transform.position.x,transform.position.y-2,transform.position.z);
        toPosition = new Vector3(transform.position.x,transform.position.y, transform.position.z);
    }







    private void Update()
    {
        
        progress += Time.deltaTime * 0.5f;
        transform.position = Vector3.Lerp(fromPosition, toPosition, progress);
    }


}
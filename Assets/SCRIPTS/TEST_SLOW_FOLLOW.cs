using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_SLOW_FOLLOW : MonoBehaviour
{
    // Start is called before the first frame update


    bool pidor;
    
    
    
    
    void Start()
    {
        // gameObject.transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y - 1f, 10), transform.position.z);

    pidor = true;   
    
    
    }





    // Update is called once per frame
    void Update()
    {


        //StartCoroutine(Pidor(1));
        //transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + 5, 100), transform.position.y, transform.position.z);
        if (pidor)
        {
            gameObject.transform.position += Vector3.down * Time.deltaTime * 0.5f;
        }
    }


    //private IEnumerator Pidor(float value)

    //{
    //    yield return new WaitForSeconds(value);
    //    gameObject.transform.position += Vector3.down * Time.deltaTime * 0.1f;
    //   // transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + 5, 100), transform.position.y, transform.position.z);

    //}



}


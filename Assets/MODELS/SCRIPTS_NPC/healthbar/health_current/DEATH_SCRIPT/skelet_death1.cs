using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skelet_death1 : MonoBehaviour, IDeath
{
    public Animator animator;
    bool pidor;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void death_activate()
    {

    }

    private void Update()
    {
        if (pidor)
        {
            gameObject.transform.position += Vector3.down * Time.deltaTime * 1f;
        }
    }

    public void Move()
    {

    }
}


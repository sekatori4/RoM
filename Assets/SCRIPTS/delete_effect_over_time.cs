using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_effect_over_time : MonoBehaviour
{
  
        void Start()
        {
            StartCoroutine(Explode()); //При создании объекта вызывается метод Explode().
        }

        IEnumerator Explode()
        {

            yield return new WaitForSeconds(0.45f); //Метод ждет 0,32 секунды, и только потом приступает к выполнению остального кода.

            Destroy(gameObject); //Объект удаляется.
        }
}
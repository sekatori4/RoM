using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_effect_over_time : MonoBehaviour
{
  
        void Start()
        {
            StartCoroutine(Explode()); //��� �������� ������� ���������� ����� Explode().
        }

        IEnumerator Explode()
        {

            yield return new WaitForSeconds(0.45f); //����� ���� 0,32 �������, � ������ ����� ���������� � ���������� ���������� ����.

            Destroy(gameObject); //������ ���������.
        }
}
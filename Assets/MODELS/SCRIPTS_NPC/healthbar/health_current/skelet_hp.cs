using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skelet_hp : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP < 0)
        {
            //��� ������ ��� ������
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            //������ ������ ���������
        }


    }
}
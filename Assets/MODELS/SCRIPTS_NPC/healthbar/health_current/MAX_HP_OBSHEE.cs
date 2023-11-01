using UnityEngine;
using UnityEngine.UI;

public class MAX_HP_OBSHEE : MonoBehaviour
{
    public float MAX_HP;
    public float curHP;
    [SerializeField] public float physic_ARMOR_percent;
    [SerializeField] public float mage_ARMOR_percent;
    [SerializeField] private Slider healthSlider;   // ������� ��
    [SerializeField] GameObject WEAPON;           // ��������� ������  --------------->>>>>>>>>>>>>>>>>>>>> ��������

    //Object script_smerti;


    public void Start()
    {
        curHP = MAX_HP;
        healthSlider.maxValue = MAX_HP;

        //----------��������  ���� ���

        Rigidbody[] rigid = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody t in rigid) { t.isKinematic = true; }

        //-------------------------
        //--------- ���������� ��� ����

        Collider[] colOFF = GetComponentsInChildren<Collider>();

        foreach (Collider t in colOFF) { t.enabled = false; }

        //-----��������� ��� ��������� (�������� ��������� �����)
        gameObject.GetComponent<BoxCollider>().enabled = true;

        //--------�������� ��������� ������

        WEAPON.GetComponent<BoxCollider>().enabled = true;
    }

    //public void TakeDamage(float phisical, float magical)
    //{
    //    TakeDamagePhys(phisical);
    //    TakeDamageMage(magical);
    //}

    public void TakeDamagePhys(float damage)
    {
        curHP = curHP - (damage - ((damage / 100) * physic_ARMOR_percent));

        CheckIfDead();
    }

    public void TakeDamageMage(float damage)
    {
        curHP = curHP - (damage - ((damage / 100) * mage_ARMOR_percent));

        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (curHP <= 0 && gameObject.tag != "corpse")
        {
            GetComponent<IDeath>().death_activate();
        }
    }

    private void OnGUI()
    {
        healthSlider.value = curHP;
    }
}
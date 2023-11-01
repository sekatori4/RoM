using UnityEngine;
using UnityEngine.UI;

public class MAX_HP_OBSHEE : MonoBehaviour
{
    public float MAX_HP;
    public float curHP;
    [SerializeField] public float physic_ARMOR_percent;
    [SerializeField] public float mage_ARMOR_percent;
    [SerializeField] GameObject skelet_poivlenie;
    [SerializeField] private Slider healthSlider;   // ПОЛОСКА ХП
    [SerializeField] GameObject WEAPON;           // КОЛЛАЙДЕР ОРУЖИЯ  --------------->>>>>>>>>>>>>>>>>>>>> ПОДУМАТЬ

    //Object script_smerti;


    public void Start()
    {
        curHP = MAX_HP;
        healthSlider.maxValue = MAX_HP;

        

        //----------РИГИБОДИ  ВЫКЛ ВСЕ

        Rigidbody[] rigid = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody t in rigid) { t.isKinematic = true; }

        //-------------------------
        //--------- Коллайдеры ВСЕ ВЫКЛ

        Collider[] colOFF = GetComponentsInChildren<Collider>();

        foreach (Collider t in colOFF) { t.enabled = false; }

        //-----Коллайдер ВКЛ ОСНОВНОМУ (ФИКСАЦИЯ ПОЛУЧЕНИЯ УРОНА)
        gameObject.GetComponent<BoxCollider>().enabled = true;

        //--------включить коллайдер оружию

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

        if (curHP <= 0)
        {
            //что делать при смерти
            //---------Выключить аниматор
            //(script_smerti as IDeath).death_activate();

            //var deathScript = GetComponent<skelet_death>();
            //deathScript.death_activate();


            //Which one?
            gameObject.GetComponent<IDeath>().death_activate();
            this.GetComponent<IDeath>().death_activate();
        }
    }

    public void TakeDamageMage(float damage)
    {

        curHP = curHP - (damage - ((damage / 100) * mage_ARMOR_percent));

        if (curHP <= 0)
        {
            //что делать при смерти

            //Which one?
            gameObject.GetComponent<IDeath>().death_activate();
            this.GetComponent<IDeath>().death_activate();
        }
    }

    private void OnGUI()
    {
        healthSlider.value = curHP;
    }
}
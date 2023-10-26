using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event Action<Health> OnHealthAdded = delegate { };
    public static event Action<Health> OnHealthRemoved = delegate { };

    [SerializeField]
    private int maxHealth = 100;

    public int CurrentHealth { get; private set; }

    public event Action<float> OnHealthChanged = delegate { };

    private void OnEnable()
    {
        CurrentHealth = maxHealth;
        OnHealthAdded(this);
    }

    public void ModifyHealth(int amount)
    {
        CurrentHealth += amount;

        float currentHealthPct = (float)CurrentHealth / (float)maxHealth;
        OnHealthChanged(currentHealthPct);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ModifyHealth(CurrentHealth - 10);
    }

    private void OnDisable()
    {
        OnHealthRemoved(this);
    }
}
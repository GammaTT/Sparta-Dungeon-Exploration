using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public event Action OnHealthChange;

    public float currentHp;
    public float maxHp;

    public Condition health;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealthChange(float change)
    {
        if (change == 0)
        {
            return;
        }

        currentHp += change;

        health.curValue = currentHp;

        OnHealthChange?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maximumHealth;
    public float actualHealth;
    public float healthPercentage;
    public Slider uiHealthPercentage;
    public UnityEvent death;
    void Start()
    {
        actualHealth = maximumHealth;
        healthPercentage = 1f;
    }
    public void DropHealth(float dmgValue)
    {
        
        actualHealth = Mathf.Clamp(actualHealth - dmgValue, 0, maximumHealth);
        UpdateHealth();
        if(healthPercentage == 0)
        {
            death.Invoke();
        }
    }
    public void RecoverHealth(float healthValue)
    {
        actualHealth = Mathf.Clamp(actualHealth + healthValue, 0, maximumHealth);
        UpdateHealth();
    }
    public void UpdateHealth()
    {
        healthPercentage = actualHealth / maximumHealth;
        if (uiHealthPercentage != null)
        {
            uiHealthPercentage.value = healthPercentage;
        }
    }
}

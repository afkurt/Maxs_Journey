using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using UnityEngine.UI;


public class HealthUI : MonoBehaviour
{
    
    public Image[] hearts;

    private void OnEnable()
    {
        HealthSystem.OnHealthChanged += UpdateHealthText;
        HealthSystem.OnDie += ShowDeath;
    }

    

    private void OnDisable()
    {
        HealthSystem.OnHealthChanged -= UpdateHealthText;
        HealthSystem.OnDie -= ShowDeath;
    }

    void UpdateHealthText(float currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHealth;
        }
    }
    void ShowDeath()
    {
        
        Invoke("UIManagerSetActive", 1f);
    }

    void UIManagerSetActive()
    {
        UIManager.Instance.onDie.SetActive(true);
    }
}

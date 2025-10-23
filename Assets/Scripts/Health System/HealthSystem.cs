using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 3;
    public float _currentHealth;
    public Animator animator;

    public static Action<float> OnHealthChanged;
    public static Action OnDie;
    

    private void Start()
    {
        _currentHealth = maxHealth;
        OnHealthChanged?.Invoke(_currentHealth);

    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        animator.SetTrigger("TakeDamage");
        OnHealthChanged?.Invoke(_currentHealth);
        CameraShake.Instance.Shake(.5f);
        if (_currentHealth <= 0)
        {
            
            OnDie?.Invoke();
            animator.SetTrigger("Die");
        }
    }

    public void Heal (float health)
    {
        _currentHealth += health;
        OnHealthChanged?.Invoke(_currentHealth);
    } 
}

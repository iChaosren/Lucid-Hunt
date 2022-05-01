using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [InlineEditor] public HealthSettings healthSettings;
    private int health = 10;

    void Awake() => health = healthSettings.maxHealth;

    public void DoDamage(int damageAmount) => health -= damageAmount;
    public void Heal(int healAmount) => health = Math.Clamp(health + healAmount, 0, healthSettings.maxHealth);
}

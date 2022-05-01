using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HealthSetting", menuName = "Settings/Health")]
public class HealthSettings : ScriptableObject
{
    [SerializeField] private int _maxHealth = 10;

    public int maxHealth { get => _maxHealth; }
}


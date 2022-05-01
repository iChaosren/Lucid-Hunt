using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickupName", menuName = "Settings/Pickup")]
public class PickupSettings : ScriptableObject
{
    [SerializeField] private float _ = 0;

    public float empty { get => _; }
}

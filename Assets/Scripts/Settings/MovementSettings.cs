using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementSetting", menuName = "Settings/Movement")]
public class MovementSettings : ScriptableObject
{
    [SerializeField] private float _speed = 50.0f;
    [SerializeField] private float _turnRate = 5.0f;

    public float speed { get => _speed; }
    public float turnRate { get => _turnRate; }
}

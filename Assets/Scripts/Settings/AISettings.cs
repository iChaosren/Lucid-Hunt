using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AI Setting", menuName = "Settings/AI")]
public class AISettings : ScriptableObject
{
    [SerializeField] private float _minimumDistanceFromPlayer = 20.0f;
    [SerializeField] private float _maximumDistanceFromPlayer = 100.0f;

    [SerializeField] private float _idleDuration = 10.0f;
    [SerializeField] private float _attackingDuration = 4.0f;
    [SerializeField] private float _fleeingDuration = 3.0f;
    [SerializeField] private float _moveInDuration = 2.0f;

    public float minimumDistanceFromPlayer { get => _minimumDistanceFromPlayer; }
    public float maximumDistanceFromPlayer { get => _maximumDistanceFromPlayer; }

    public float idleDuration { get => _idleDuration; }
    public float attackingDuration { get => _attackingDuration; }
    public float fleeingDuration { get => _fleeingDuration; }
    public float moveInDuration { get => _moveInDuration; }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "ProjectileName", menuName = "Settings/Projectile")]
public class ProjectileSettings : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private AudioClip _launchClip;
    [SerializeField] private ProjectileType _projectileType = ProjectileType.Straight;

    [SerializeField] private float _speed = 50f;
    [SerializeField, ShowIf("_projectileType", ProjectileType.Following)] private float _turnRate = 50f;

    public GameObject prefab { get => _prefab; }
    public AudioClip launchClip { get => _launchClip; }
    public ProjectileType projectileType { get => _projectileType; }

    public float speed { get => _speed; }
    public float turnRate { get => _turnRate; }
}

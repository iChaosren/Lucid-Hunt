using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    public Transform emissionTransform;
    public ProjectileSettings projectileSettings;

    private IProjectileManager projectileManager;

    void Awake() => projectileManager = new ProjectileManager(emissionTransform, projectileSettings, Instantiate);

    void Update()
    {
        if (PrimaryFireInputGlobal.Instance.PrimaryFired)
            Debug.Log("Player Firing");
    }
}

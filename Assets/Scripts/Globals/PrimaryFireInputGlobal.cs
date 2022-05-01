using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryFireInputGlobal : GlobalBehaviour, IPrimaryAttackInput
{
    private static PrimaryFireInputGlobal _instance;
    public static PrimaryFireInputGlobal Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError($"{nameof(PrimaryFireInputGlobal)} does not exist inside of the scene. Instantiate at least once in scene.");
            return _instance;
        }
    }

    public PrimaryFireInputGlobal() : base() => _instance = this;

    public bool PrimaryFired { get; private set; } = false;

    void Update() => PrimaryFired = Input.GetButtonDown("Fire1");
}

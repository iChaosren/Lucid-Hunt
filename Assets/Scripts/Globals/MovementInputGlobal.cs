using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputGlobal : GlobalBehaviour, IMovementInput
{
    private static MovementInputGlobal _instance;
    public static MovementInputGlobal Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError($"{nameof(MovementInputGlobal)} does not exist inside of the scene. Instantiate at least once in scene.");
            return _instance;
        }
    }

    public MovementInputGlobal() : base() => _instance = this;

    public float XAxis { get; private set; } = 0.0f;
    public float YAxis { get; private set; } = 0.0f;

    void Update()
    {
        XAxis = Input.GetAxis("Horizontal");
        YAxis = Input.GetAxis("Vertical");
    }
}

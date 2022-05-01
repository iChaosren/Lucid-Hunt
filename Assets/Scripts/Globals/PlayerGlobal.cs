using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobal : GlobalBehaviour
{
    private static PlayerGlobal _instance;
    public static PlayerGlobal Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError($"{nameof(PlayerGlobal)} does not exist inside of the scene. Instantiate at least once in scene.");
            return _instance;
        }
    }

    public PlayerGlobal() : base() => _instance = this;

    public GameObject PlayerObject { get { return gameObject; } }
    public Transform PlayerTransform { get { return transform; } }
}

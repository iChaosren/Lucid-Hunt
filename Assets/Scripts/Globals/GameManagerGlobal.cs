using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerGlobal : MonoBehaviour
{
    private static GameManagerGlobal _instance;
    public static GameManagerGlobal Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError($"{nameof(GameManagerGlobal)} does not exist inside of the scene. Instantiate at least once in scene.");
            return _instance;
        }
    }

    public GameManagerGlobal() : base() => _instance = this;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}

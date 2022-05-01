using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectDelegates
{
    public delegate Object InstantiationFunction(Object prefab, Vector3 position, Quaternion rotation);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRequiresInstantiate
{
    GameObjectDelegates.InstantiationFunction Instantiate { get; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAIStateManager
{
    public Transform aiTransform { get; }
    BrainState currentState { get; }
    AISettings aiSettings { get; }
    IMovementManager movementManager { get; }
    IProjectileManager projectileManager { get; }

    void UpdateState();
}

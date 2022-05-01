using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementManager
{
    Transform transform { get; }
    MovementSettings settings { get; }

    /// <summary>
    /// Move in a specified direction this frame.
    /// Needs to be called inside of FixedUpdate/Update
    /// </summary>
    /// <param name="direction">Input X and Y values</param>
    void MoveInDirection(Vector2 direction);
}

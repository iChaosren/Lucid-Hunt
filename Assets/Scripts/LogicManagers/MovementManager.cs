using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : IMovementManager
{
    public Transform transform { get; private set; }
    public MovementSettings settings { get; private set; }

    public MovementManager(Transform transform, MovementSettings settings)
    {
        this.transform = transform;
        this.settings = settings;
    }

    public void MoveInDirection(Vector2 direction)
    {
        transform.Rotate(-Vector3.forward * direction.x * settings.turnRate * Time.deltaTime);
        transform.position += transform.up * direction.y * settings.speed * Time.deltaTime;
    }
}

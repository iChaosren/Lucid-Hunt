using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardTarget : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target == null)
            return;

        transform.rotation = Quaternion.FromToRotation(Vector2.down, (transform.position - target.position).normalized);
    }
}

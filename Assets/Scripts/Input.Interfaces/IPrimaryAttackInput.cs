using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPrimaryAttackInput
{
    /// <summary>
    /// Whether or not the Primary Attack Input had its `KeyDown` this frame
    /// </summary>
    public bool PrimaryFired { get; }
}

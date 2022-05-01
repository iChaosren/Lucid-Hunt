using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputReceiver : MonoBehaviour, IMovementInput
{
    public float XAxis { get => MovementInputGlobal.Instance.XAxis; }
    public float YAxis { get => MovementInputGlobal.Instance.YAxis; }
}

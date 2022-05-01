using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerMovementController : MonoBehaviour
{
    private IMovementManager movementManager { get; set; }

    [InlineEditor] public MovementSettings movementSettings = null;
    [InlineEditor] public ZoomSettings zoomWhenSlow = null;
    [InlineEditor] public ZoomSettings zoomWhenFast = null;

    void Awake() => movementManager = new MovementManager(transform, movementSettings);

    void Update()
    {
        movementManager.MoveInDirection(new Vector2(MovementInputGlobal.Instance.XAxis, MovementInputGlobal.Instance.YAxis));
        ZoomGlobal.Instance.SetZoom(Mathf.Abs(MovementInputGlobal.Instance.YAxis) > 0.5f ? zoomWhenFast : zoomWhenSlow);
    }
}

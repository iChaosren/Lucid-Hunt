using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZoomTransition", menuName = "Settings/Zoom Transition")]
public class ZoomSettings : ScriptableObject
{
    [SerializeField] private float _zoomLevel = 100.0f;
    [SerializeField] private float _transitionDuration = 1.0f;
    [SerializeField] private EasingFunction.Ease _zoomEasing = EasingFunction.Ease.EaseInCubic;

    public float zoomLevel { get => _zoomLevel; }
    public float transitionDuration { get => _transitionDuration; }
    public EasingFunction.Ease zoomEasing { get => _zoomEasing; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomManager : IZoomManager
{
    public ZoomSettings zoomSettings { get; private set; }
    public float originalZoom { get; private set; } = 0.0f;
    public float lastZoom { get; private set; } = 0.0f;
    public float deltaSetZoomTime { get; private set; }

    public ZoomManager(ZoomSettings startingZoomSettings)
    {
        zoomSettings = startingZoomSettings;
        CurrentEeasingFunction = EasingFunction.GetEasingFunction(zoomSettings.zoomEasing);
    }

    private EasingFunction.Function CurrentEeasingFunction;

    public void SetZoom(ZoomSettings newZoom)
    {
        if(newZoom == zoomSettings)
            return;

        zoomSettings = newZoom;
        deltaSetZoomTime = 0.0f;
        originalZoom = lastZoom;
        CurrentEeasingFunction = EasingFunction.GetEasingFunction(newZoom.zoomEasing);
    }

    public void UpdateZoom(ref float zoomDistance)
    {
        lastZoom = zoomDistance;
        float t = Mathf.Clamp01(deltaSetZoomTime / zoomSettings.transitionDuration);

        zoomDistance = CurrentEeasingFunction.Invoke(originalZoom, zoomSettings.zoomLevel, t);
        deltaSetZoomTime += Time.deltaTime;
    }
}

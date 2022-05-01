using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZoomManager
{
    ZoomSettings zoomSettings { get; }
    float originalZoom { get; }
    float lastZoom { get; }
    float deltaSetZoomTime { get; }

    public void SetZoom(ZoomSettings newZoom);
    public void UpdateZoom(ref float zoomDistance);
}

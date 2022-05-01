using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZoomGlobal : GlobalBehaviour
{
    private static ZoomGlobal _instance;
    public static ZoomGlobal Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError($"{nameof(ZoomGlobal)} does not exist inside of the scene. Instantiate at least once in scene.");
            return _instance;
        }
    }

    private IZoomManager zoomManager;
    private CinemachineFramingTransposer framingTransposer;

    public ZoomSettings initialZoomSettings;
    public CinemachineVirtualCamera sceneVirtualCamera;

    private CinemachineFramingTransposer FramingTransposer
    {
        get
        {
            if (framingTransposer == null)
            {
                var pipelines = sceneVirtualCamera.GetComponentPipeline();
                framingTransposer = pipelines.Where(p => p.GetType().Name == nameof(CinemachineFramingTransposer)).FirstOrDefault() as CinemachineFramingTransposer;
            }
            return framingTransposer;
        }
    }

    public ZoomGlobal() : base() => _instance = this;
    void Awake() => zoomManager = new ZoomManager(initialZoomSettings);
    void Update() => zoomManager.UpdateZoom(ref FramingTransposer.m_CameraDistance);
    public void SetZoom(ZoomSettings newZoom) => zoomManager.SetZoom(newZoom);
}

using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static Action<int, int> cameraAction;
    
    [SerializeField] private CinemachineClearShot clearShot;
    [SerializeField] private CinemachineCamera[] cameras;

    void OnEnable()
    {
        cameraAction += SetCamera;
    }
    
    void Start()
    {
        cameras = clearShot.GetComponentsInChildren<CinemachineCamera>();
    }
    
    void OnDisable()
    {
        cameraAction -= SetCamera;
    }

    public void SetCamera(int index, int priority)
    {
        // Player 카메라의 우선순위 = 10
        cameras[index].Priority = priority;
    }
}
using System;
using System.Linq;
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

    private void SetCamera(int index, int priority)
    {
       cameras[index].Priority = priority;
    }

    public static void ChangeCamera(int index, int priority)
    {
        cameraAction?.Invoke(index, priority);
    }
}

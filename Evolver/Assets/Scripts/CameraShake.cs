using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform = default;
    private Vector3 _orginalPosOfCam = default;
    public float shakeFrequency = default;
    public static CameraShake instance;
    void Start()
    {
        _orginalPosOfCam = cameraTransform.position;
        instance = this;
    }

    
   public void cameraShake()
    {
        cameraTransform.position = _orginalPosOfCam + Random.insideUnitSphere * shakeFrequency;
            StopShake();
    }

    public void StopShake()
    {
        cameraTransform.position = _orginalPosOfCam;
    }
}

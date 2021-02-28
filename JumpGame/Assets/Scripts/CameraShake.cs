using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{

    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntensity;


 
    public static CameraShake Instance { get;  set; }

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

       
    }

    public void ShakeCamera(float intensity, float time)
    {



        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin=

    cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
            shakeTimer = time;
            startingIntensity = intensity;
            shakeTimerTotal = time;
       
        
    }

    private void Update()
    {

     
        if (shakeTimer > 0)
            {
                shakeTimer -= Time.deltaTime;
                if (shakeTimer <= 0f)
                {
                    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                      cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                
                    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 
                    Mathf.Lerp(startingIntensity, 0f, 1-(shakeTimer / shakeTimerTotal));
                }
        }
    }

   
}

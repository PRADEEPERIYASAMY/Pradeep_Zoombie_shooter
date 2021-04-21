using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;

    Light light;

    private void Start()
    {
        light = GetComponent<Light>();
    }
    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if(light.spotAngle <= minAngle)
        {
            return;
        }
        else
        {
            light.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {
        light.intensity -= lightDecay * Time.deltaTime;
    }

    public void RestoreAngle(float restoreAngle)
    {
        light.spotAngle = restoreAngle;
    }
    public void RestoreLight(float intensityAmount)
    {
        light.intensity = intensityAmount;
    }
}

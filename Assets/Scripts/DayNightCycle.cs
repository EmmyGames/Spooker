using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    //SKYBOX
    public float exposure;
    public float environmentSpeed;

    //DIRECTIONAL LIGHT
    public float lightIntensity;
    public Light directionalLight;

    void Update()
    {
        //SKYBOX
        RenderSettings.skybox.SetFloat("_Exposure", exposure * Time.time);
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * environmentSpeed);

        //DIRECTIONAL LIGHT
        directionalLight.intensity = lightIntensity;
    }
}

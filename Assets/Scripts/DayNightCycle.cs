using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float exposure;
    public float environmentSpeed;
    
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Exposure", exposure * Time.time);
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * environmentSpeed);
    }
}

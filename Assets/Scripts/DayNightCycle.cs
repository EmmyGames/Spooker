using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float exposure;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Exposure", exposure);
    }
}

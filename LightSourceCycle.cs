using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LightSourceCycle : MonoBehaviour
{
    private Light2D l2d;

    // Start is called before the first frame update
    private void Start()
    {
        l2d = GetComponent<Light2D>();
        l2d.intensity = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        /*if(DayNightCycle.day)
        {
            l2d.intensity += (0.5f * DayNightCycle.cycleTime) *  Time.deltaTime;
        }
        else if (DayNightCycle.night)
        {
            l2d.intensity -= (0.5f * DayNightCycle.cycleTime) * Time.deltaTime;
        }*/

        l2d.intensity = DayNightCycle.vo.weight * 10f;
    }
}

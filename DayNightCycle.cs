using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class DayNightCycle : MonoBehaviour
{

    public static Volume vo;
    public static bool day, night;
    [SerializeField] public static float cycleTime = 0.001f;
    // Start is called before the first frame update
    private void Start()
    {
        vo = GetComponent<Volume>();
        day = true;
        night = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (day)
        {
            vo.weight += cycleTime * Time.deltaTime;
            if (vo.weight > 1f)
            {
                day = false;
                night = true;
            }
        }
        if(night)
        { 
            vo.weight -= cycleTime * Time.deltaTime;
            if(vo.weight  < 0f) 
            {
                day = true;
                night = false;
            }
        }
    }
}

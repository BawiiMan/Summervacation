using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float cycleLength = 240f;
    public Light directionalLight;
    

    void Update()
    {
        float cycleCompletionPercentage = (Time.time % cycleLength) / cycleLength;      //상태 % (0 ~ 1)
        float sunAngle = cycleCompletionPercentage * 360f;                              //받아온 %에 360도를 곱한다.
        directionalLight.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0);      //시간에 따른 태양 빛 회전
    }
}

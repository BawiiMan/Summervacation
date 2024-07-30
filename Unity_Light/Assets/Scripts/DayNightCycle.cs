using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float cycleLength = 240f;
    public Light directionalLight;
    

    void Update()
    {
        float cycleCompletionPercentage = (Time.time % cycleLength) / cycleLength;      //���� % (0 ~ 1)
        float sunAngle = cycleCompletionPercentage * 360f;                              //�޾ƿ� %�� 360���� ���Ѵ�.
        directionalLight.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0);      //�ð��� ���� �¾� �� ȸ��
    }
}

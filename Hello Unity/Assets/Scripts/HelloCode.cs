using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    void Start()
    {
        for(int i = 1; i < 10; i++)         //9단
        {
            for (int j = 1; j < 10; j++)        //9단 총 81회 진행
            {
                int temp = i * j;                               //임의의 변수를 생성하여 i곱하기 j값을 넣어준다.   
                Debug.Log(i + " x " + j + " = " + temp);
            }
        }
    }
}

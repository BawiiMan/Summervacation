using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    void Start()
    {
        for(int i = 1; i < 10; i++)         //9��
        {
            for (int j = 1; j < 10; j++)        //9�� �� 81ȸ ����
            {
                int temp = i * j;                               //������ ������ �����Ͽ� i���ϱ� j���� �־��ش�.   
                Debug.Log(i + " x " + j + " = " + temp);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public string dogName;  //���� �̸�
    public static int count = 0;               //���α׷��� �����ϴ� ���� �Ѽ�

    private void Awake()
    {
        count++;

        Debug.Log("Count : " + count);
    }
}

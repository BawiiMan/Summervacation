using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public string dogName;  //개의 이름
    public static int count = 0;               //프로그램에 존재하는 개의 총수

    private void Awake()
    {
        count++;

        Debug.Log("Count : " + count);
    }
}

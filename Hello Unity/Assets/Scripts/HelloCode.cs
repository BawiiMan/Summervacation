using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    public int[] students;                 //배열 을 할당을 꼭 해줘야만함
    public float[] Heights;
    public bool[] flags;
    public string[] strings;
    public GameObject[] gameObjects;

    void Start()
    {

        for(int i = 0; i < students.Length; i++)
        {
            students[i] = Random.Range(50, 100); //50이상 100미만 사이의 값을 리턴해주는 랜덤 함수
        }

        for(int i = 0; i < students.Length; i++)
        {
            Debug.Log(i.ToString() + " 번의 학생의 점수 : " + students[i]);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    public int[] students;                 //�迭 �� �Ҵ��� �� ����߸���
    public float[] Heights;
    public bool[] flags;
    public string[] strings;
    public GameObject[] gameObjects;

    void Start()
    {

        for(int i = 0; i < students.Length; i++)
        {
            students[i] = Random.Range(50, 100); //50�̻� 100�̸� ������ ���� �������ִ� ���� �Լ�
        }

        for(int i = 0; i < students.Length; i++)
        {
            Debug.Log(i.ToString() + " ���� �л��� ���� : " + students[i]);
        }

    }
}

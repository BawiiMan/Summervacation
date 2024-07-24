using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ������Ʈ�� ��� �������� �����̴� ��ũ��Ʈ


public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;               //�̵� �ӵ�

    void Update()
    {
        if (!GameManager.Instance.isGameOver)        //���� ������ �ƴ϶��
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);             //�ʴ� speed �ӵ��� �������� �����̵�
        }
    }
}

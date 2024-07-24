using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;      //��ֹ� ������Ʈ��
    private bool stepped = false;       //�÷��̾� ĳ���Ͱ� ��Ҵ°�

    //������Ʈ�� Ȱ��ȭ�� ������ �Ź� ����Ǵ� �޼���
    private void OnEnable()
    {
        //������ �����ϴ� ó��
        stepped = true;     //���� ������ stepped�� flase�� �ʱ�ȭ

        //��ֹ� �� ��ŭ ����
        for (int i = 0; i < obstacles.Length; i++)
        {
            if(Random.Range(0, 3) == 0)     // 1/3Ȯ���� Ȱ��ȭ
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
        if(collision.collider.tag == "Player" && !stepped)
        {
            //������ �߰��ϰ� ���� ���¸� ������ ����
            stepped = true;
            GameManager.Instance.AddScore(1);
        }
    }
}

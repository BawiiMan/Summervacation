using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal                 //���� ������Ʈ�� �ƴ� �Ϲ� Ŭ�����̱� ������ ���� ��� �Ѱ��� ����.
{
    //������ ���� ����
    public string name;             //�̸� ��������
    public string sound;            //�����Ҹ� ���� ����

    //�����Ҹ��� ����ϴ� �޼���
    public void PlaySound()
    {
        Debug.Log(name + " : " +  sound);           //�α׷� �̸��� �����Ҹ��� ����Ѵ�.
    }
}

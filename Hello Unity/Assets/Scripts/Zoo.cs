using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    void Start()
    {
        Animal tom = new Animal();          //new �� Ŭ������ �Ҵ���
        tom.name = "��";                     //������Ʈ ������ ���� -> ��� -> ����� �����ϱ� ���ؼ��� ��(.)�����ڷ� ����[���������ڰ� ����� ��츸]
        tom.sound = "�Ŀ�!";

        tom.PlaySound();

        //�ٸ� ��ü�� �Ҵ��Ͽ� ���������� �����ϴ� ���� �����ֱ� ���ؼ�
        Animal bob = new Animal();
        bob.name = "��";
        bob.sound = "��!";

        bob.PlaySound();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8.0f;          //ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody;  //�̵��� ����� ������ٵ� ������Ʈ
    // Start is called before the first frame update
    void Start()
    {
        //���� ������Ʈ Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();

        //������ٵ��� �ӵ� = ���� ����(transform.forward , ���� z���� ��) * �̵��ӷ�
        bulletRigidbody.velocity = transform.forward * speed;


        //3�� �ڿ� �ڽ��� ���� ������Ʈ�� �ı�
        Destroy(gameObject, 3f);                //Destory(Object) �Է��� ������Ʈ�� �ı�
    }

    //Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    private void OnTriggerEnter(Collider other)
    {
        //�浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.gameObject.tag == "Player")
        {
            //���� ���� ������Ʈ���� PlayerController ������Ʈ�� ��������
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

            //�������� ���� PlayerContoroller ������Ʈ�� �������µ� �����ߴٸ�
            if(playerController != null)
            {
                //���� PlayerController ������Ʈ�� Die() �޼��� ����
                playerController.Die();
            }
        }
    }
}

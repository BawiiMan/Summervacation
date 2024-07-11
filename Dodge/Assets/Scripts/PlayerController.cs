using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody playRigidbody;             //�̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f;                    //�̵� �ӷ�

    // Start is called before the first frame update
    void Start()
    {
            playRigidbody = GetComponent<Rigidbody>();  //������ �ٵ� ������Ʈ�� ã�Ƽ� palyRigidbody ������ �Ҵ� (GetComponent ���ϰ� ŭ)
    }

    // Update is called once per frame
    void Update()
    {
        //������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����ؼ� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 �ӵ��� (xSpeed, 0, zSpeed)
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        //������ �ٵ��� �ӵ��� newVelocity �Ҵ�
        playRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);        //�ڽ��� ���ӿ�����Ʈ�� �����Ͽ� ��Ȱ��ȭ

        GameManager gameManager = FindObjectOfType<GameManager>();          //���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ�
        gameManager.EndGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10f;
    public string speedParameterName = "Speed";
    public GameObject scoreProjectorPrefabs;            //ĳ���� �̵� ��ġ�� �˷��� ������
    public NavMeshAgent agent;                          //�׺�޽� ������Ʈ Ŭ���� �Ҵ�

    public Animator animator;
    private Camera mainCamera;                          //����ĳ��Ʈ�� �ϱ� ���� ī�޶� �Ҵ�

    public QuadScopeProjector scopeProjector;
    void Start()
    {
        mainCamera = Camera.main;                           //���� ī�޶� �Ҵ�
        agent.speed = moveSpeed;                            //�̵� ���ǵ� ����

        GameObject projectorObj = Instantiate(scoreProjectorPrefabs);
        scopeProjector = projectorObj.GetComponent<QuadScopeProjector>();
        projectorObj.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //ī�޶󿡼� ��ũ����ġ�� ���콺 �����ǿ��� 30�� ����ĳ�����Ѵ�.
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit) )  //����ĳ���ÿ� HiT�� ���� ���
            {
                agent.SetDestination(hit.point);    //������Ʈ�� �������� ��Ʈ����Ʈ�̴�.
                scopeProjector.gameObject.SetActive(true);
                scopeProjector.ShowAtPosition(hit.point);
            }
        }

        float currentSpeed = Mathf.Clamp01(agent.velocity.magnitude / agent.speed);     //������Ʈ �ӵ��� 0~1���̰����� ����
        animator.SetFloat(speedParameterName, currentSpeed);                            //���� �ִϸ��̼� ���� �־��ش�.

        if(agent.velocity.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(agent.desiredVelocity, Vector3.up); //�̵��� ȸ�� ���� ���Ѵ�.
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);  //ȸ�� ���� �������ش�.

        }

        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            scopeProjector.StartFading();
        }
    }
}

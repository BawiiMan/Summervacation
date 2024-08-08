using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10f;
    public string speedParameterName = "Speed";
    public GameObject scoreProjectorPrefabs;            //캐릭터 이동 위치를 알려줄 프리팹
    public NavMeshAgent agent;                          //네브메시 에이전트 클래스 할당

    public Animator animator;
    private Camera mainCamera;                          //레이캐스트를 하기 위해 카메라 할당

    public QuadScopeProjector scopeProjector;
    void Start()
    {
        mainCamera = Camera.main;                           //메인 카메라 할당
        agent.speed = moveSpeed;                            //이동 스피드 설정

        GameObject projectorObj = Instantiate(scoreProjectorPrefabs);
        scopeProjector = projectorObj.GetComponent<QuadScopeProjector>();
        projectorObj.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //카메라에서 스크린위치의 마우스 포지션에서 30로 레이캐스팅한다.
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit) )  //레이캐스팅에 HiT가 있을 경우
            {
                agent.SetDestination(hit.point);    //에이전트의 목적지는 히트포인트이다.
                scopeProjector.gameObject.SetActive(true);
                scopeProjector.ShowAtPosition(hit.point);
            }
        }

        float currentSpeed = Mathf.Clamp01(agent.velocity.magnitude / agent.speed);     //에이전트 속도를 0~1사이값으로 변경
        animator.SetFloat(speedParameterName, currentSpeed);                            //블랜딩 애니메이션 값에 넣어준다.

        if(agent.velocity.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(agent.desiredVelocity, Vector3.up); //이동할 회전 값을 구한다.
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);  //회전 값을 보정해준다.

        }

        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            scopeProjector.StartFading();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody playRigidbody;             //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;                    //이동 속력

    // Start is called before the first frame update
    void Start()
    {
            playRigidbody = GetComponent<Rigidbody>();  //리지드 바디 컴포넌트를 찾아서 palyRigidbody 변수에 할당 (GetComponent 부하가 큼)
    }

    // Update is called once per frame
    void Update()
    {
        //수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 사용해서 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xSpeed, 0, zSpeed)
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        //리지드 바디의 속도에 newVelocity 할당
        playRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);        //자신의 게임오브젝트에 접근하여 비활성화

        GameManager gameManager = FindObjectOfType<GameManager>();          //씬에 존재하는 GameManager 타입의 오브젝트를 찾아서
        gameManager.EndGame();
    }
}

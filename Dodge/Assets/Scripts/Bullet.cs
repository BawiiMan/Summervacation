using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8.0f;          //탄알 이동 속력
    private Rigidbody bulletRigidbody;  //이동에 사용할 리지드바디 컴포넌트
    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();

        //리지드바디의 속도 = 앞쪽 방향(transform.forward , 보통 z축이 앞) * 이동속력
        bulletRigidbody.velocity = transform.forward * speed;


        //3초 뒤에 자신의 게임 오브젝트를 파괴
        Destroy(gameObject, 3f);                //Destory(Object) 입력한 오브젝트를 파괴
    }

    //트리거 충돌 시 자동으로 실행되는 메서드
    private void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.gameObject.tag == "Player")
        {
            //상대방 게임 오브젝트에서 PlayerController 컴포넌트를 가져오기
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

            //상대방으로 부터 PlayerContoroller 컴포넌트를 가져오는데 성공했다면
            if(playerController != null)
            {
                //상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }
}

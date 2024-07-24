using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 700;               //점프에 사용할 힘

    private int jumpCount = 0;                  //점프 카운트
    private bool isGrounded = false;            //땅 체크
    private bool isDead = false;                //사망 체크

    private Rigidbody2D playerRigidbody;        //플레이어 리지드바디 변수
    private Animator animator;                  //애니메이터 변수
    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트로 부터 사용할 컴포넌트들을 가져와 변수에 할당
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;                 //사망시 처리를 더이상 진행하지 않고 종료

        if(Input.GetMouseButtonDown(0) && jumpCount < 2)        //마우슨 왼쪽 버튼을 눌렀으면서 동시에 최대 점프가 횟수 2에 도달하지 않았다면
        {
            jumpCount++;            //점프 횟수 증가
            playerRigidbody.velocity = Vector2.zero;                //점프 직전에 속도를 순간적으로 (0,0)으로 변경
            playerRigidbody.AddForce(new Vector2(0, jumpForce));    //리지드바디에 위쪽으로 힘들 추가
        }
        else if(Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)          //마우스 왼쪽 버튼에서 손을 떼는 순간 && 위로 상승중이라면
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;                 //현재 속도를 절반으로 변경
        }

        animator.SetBool("Grounded", isGrounded);       //애니메이터의 Grounded 파라미터를 isGrounded 값으로 갱신
    }

    void Die()
    {
        animator.SetTrigger("Die");                     //애니메이터의 Die 트리거를 셋팅
        playerRigidbody.velocity = Vector2.zero;        //속도를 제로로 변경
        isDead = true;                                  //사망 상태를 true로 변경

        //게임 매니저의 게임 오버 처리 실행
        GameManager.Instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Dead" && !isDead)
        {
            //충돌한 상대방의 태그가 Dead이며 아직 사망하지 않았다면 Die()실행
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)      
    {
        if(collision.contacts[0].normal.y > 0.7f)   //어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있으면
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)       //어떤 콜라이더에서 떼어진 경우
    {
        isGrounded = false;
    }
}

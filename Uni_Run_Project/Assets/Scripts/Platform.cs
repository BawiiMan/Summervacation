using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;      //장애물 오브젝트들
    private bool stepped = false;       //플레이어 캐릭터가 밟았는가

    //컴포넌트가 활성화될 때마다 매번 실행되는 메서드
    private void OnEnable()
    {
        //발판을 리셋하는 처리
        stepped = true;     //밟힘 상태의 stepped를 flase로 초기화

        //장애물 수 만큼 루프
        for (int i = 0; i < obstacles.Length; i++)
        {
            if(Random.Range(0, 3) == 0)     // 1/3확률로 활성화
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
        //플레이어 캐릭터가 자신을 밟았을 때 점수를 추가하는 처리
        if(collision.collider.tag == "Player" && !stepped)
        {
            //점수를 추가하고 밟힘 상태를 참으로 변경
            stepped = true;
            GameManager.Instance.AddScore(1);
        }
    }
}

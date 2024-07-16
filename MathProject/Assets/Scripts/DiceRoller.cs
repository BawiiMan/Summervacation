using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public GameObject dicePrefabs;                      //다이스 오브젝트
    public float throwForce = 5.0f;                     //다이스 던지는 힘
    public float torqueForce = 2f;                      //다이스 회전력

    private Rigidbody diceRigidbody;                    //다이스 강체
    private bool isRolling = false;                     //롤링 플래그
    private Vector3[] diceDirections = new Vector3[6];   //6면체 Vector값 설정
    // Start is called before the first frame update
    void Start()
    {
        //주사위 방향 초기화
        diceDirections[0] = Vector3.forward;                //  1
        diceDirections[1] = Vector3.up;                     //  2
        diceDirections[2] = Vector3.left;                   //  3
        diceDirections[3] = Vector3.right;                  //  4    
        diceDirections[4] = Vector3.down;                   //  5
        diceDirections[5] = Vector3.back;                   //  6
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isRolling)               //스페이스를 누르고 다이스가 롤링 중이지 않을때
        {
            RollDice();
        }

        if(isRolling && diceRigidbody.IsSleeping())                     //롤링 중인 상태이고 강체가 멈췄을 때
        {
            CheckDiceResult();
            isRolling = false;
        }
    }

    void RollDice()
    {
            GameObject diceInsance = Instantiate(dicePrefabs, transform.position, Random.rotation);         //다이스 프리팹을 생성한다. 회전을 랜덤이다.
            diceRigidbody = diceInsance.GetComponent<Rigidbody>();                                          //생성한 다이스 프리팹에서 강첼르 가져온다.

            //주사위에 위쪽으로 힘을 가함
            diceRigidbody.AddForce(Vector3.up * throwForce, ForceMode.Impulse);

            //주사위에 회전력을 가함
            diceRigidbody.AddTorque(Random.insideUnitSphere * torqueForce, ForceMode.Impulse);

            isRolling = true;                                                                               //회전 상태를 true로 변경한다.
    }
    void CheckDiceResult()                          //다이스 결과 체크하는 함수
    {
        float bestDotProduct = float.NegativeInfinity;
        int result = 0;

        for (int i = 0; i < 6; i++)
        {
            //주사위 로컬 좌표계의 방향을 월드 좌표계로 변환
            Vector3 worldDirection = diceRigidbody.transform.TransformDirection(diceDirections[i]);
            //월드 좌표 변환된 방향과 내적을 계산
            float dotProduct = Vector3.Dot(worldDirection, Vector3.up);

            if (dotProduct > bestDotProduct)
            {
                bestDotProduct = dotProduct;
                result = i + 1;                     //인덱스가 0부터 시작하므로 1을 더해서 결과 값을 알려준다.
            }
        }

        //외적을 사용하여 주사위의 회전 방향 확인
        Vector3 diceRight = diceRigidbody.transform.right;
        Vector3 diceForward = diceRigidbody.transform.forward;
        Vector3 rotationDirection = Vector3.Cross(diceRight, diceForward);

        if(Vector3.Dot(rotationDirection, Vector3.up) > 0)
        {
            Debug.Log("주사위가 시계 방향으로 회전");
        }
        else
        {
            Debug.Log("주사위가 반시계 방향으로 회전");
        }

        Debug.Log("주사위 결과 : " + result);
    }
}

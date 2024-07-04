using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public int Hp = 10;                  //체력 선언
    public float Distance = 0f;          //이동거리

    public int NeedHp = 2;                      //필요 체력
    public float MoveDistance = 3.5f;       //이동 가능 거리

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))         //키 입력은 보통 Update에서 진행하고 if문을 통해서 키가 입력이 되었을 때[스페이스를 눌렀을 때]
        {
            if(NeedHp > Hp)
            {
                Debug.Log("더 이상 이동 할 수 없습니다. ");        //체력이 없으므로 이동 할 수 없다.
            }
            else
            {
                ObjectMove(NeedHp, MoveDistance);           //함수를 통해 이동 시킨다.
                gameObject.transform.position = new Vector3(0, Distance, 0);   //이 오브젝트를 이동시킨다.
            }
        }

    }

    void ObjectMove(int _Hp, float _MoveDistance)
    {
        Hp = Hp - _Hp;                              //함수 동작할때 인수로 받아온 Hp를 뺀다.
        Distance = Distance + _MoveDistance;        //함수 동작할때 인수로 받아온 거리를 더한다.

        Debug.Log("남은 체력 : " + Hp);
        Debug.Log("이동 거리 : " + Distance);
    }
}

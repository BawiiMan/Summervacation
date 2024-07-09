using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal                 //게임 오브젝트가 아닌 일반 클래스이기 때문에 따로 상속 한것이 없다.
{
    //동물에 대한 변수
    public string name;             //이름 변수선언
    public string sound;            //울음소리 변수 선언

    //울음소리를 재생하는 메서드
    public void PlaySound()
    {
        Debug.Log(name + " : " +  sound);           //로그로 이름과 울음소리를 출력한다.
    }
}

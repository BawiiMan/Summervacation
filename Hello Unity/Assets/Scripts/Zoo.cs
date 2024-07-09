using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    void Start()
    {
        Animal tom = new Animal();          //new 로 클래스를 할당함
        tom.name = "톰";                     //오브젝트 내부의 변수 -> 멤버 -> 멤버에 접근하기 위해서는 점(.)연산자로 접근[접근제어자가 허락할 경우만]
        tom.sound = "냐옹!";

        tom.PlaySound();

        //다른 객체를 할당하여 독립적으로 동작하는 것을 보여주기 위해서
        Animal bob = new Animal();
        bob.name = "밥";
        bob.sound = "멍!";

        bob.PlaySound();
    }
}

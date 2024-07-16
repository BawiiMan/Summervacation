using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform childTransform;                //움직일 자식 게임 오브젝트의 트랜폼 선언
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -1, 0);             //자신의 전역 위치를 (0, -1, 0)으로 변경
        childTransform.localPosition = new Vector3(0, 2, 0);    //자식의 지역 위치를 (0, 2, 0)으로 변경

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30));           //자신의 전역 회전을 (0, 0, 30)으로 변경
        transform.localRotation = Quaternion.Euler(new Vector3(0, 60, 0));      //자식의 지역 회전을 (0, 60, 0)으로 변경
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))       //위쪽키를 누를경우 평행이동
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.DownArrow))       //아래쪽키를 누를경우 평행이동
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))       //왼쪽키를 누를경우 평행이동
        {
            transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);      //자신을 초당(0, 0, 180)회전
            childTransform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime); //자식을 초당 (0, 180, 0) 회전
        }
        if (Input.GetKey(KeyCode.RightArrow))       //오른쪽키를 누를경우 평행이동
        {
            transform.Rotate(new Vector3(0, 0, -180) * Time.deltaTime);      //자신을 초당(0, 0, -180)회전
            childTransform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime); //자식을 초당 (0, -180, 0) 회전
        }
    }
}

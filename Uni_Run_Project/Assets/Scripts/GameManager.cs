using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;     //싱글톤을 할당할 전역 변수

    public bool isGameOver = false;     //게임오버 상태
    public Text scoreText;              //점수를 출력할 UI텍스트\
    public GameObject gameOverUI;       //게임오버시 활성화할 UI 게임 오브젝트

    private int score = 0;          //게임 점수

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Scene에 두개 이상의 게임 매니저가 존재합니다!");           //경고 창을 띄워주고
            Destroy(gameObject);                                                        //자신을 삭제한다.
        }
    }
    void Update()
    {
        if(isGameOver && Input.GetMouseButtonDown(0))               //GameOver가 되고 마우스 왼쪽 버튼을 클릭하면
        {
            //SceneManager.GetActiveScene().name 지금 플레이하고 있는 현재 활성화된 Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);     //LoadScene(Name)은 NameScene을 불러온다.
        }
    }

    public void AddScore(int newScore)      //스코어를 더하고 UI에 반영한다.
    {
        //게임 오버상태가 아니라면
        if(!isGameOver)
        {
            score += newScore;      //점수 증가
            scoreText.text = "Score : " + score;        //텍스트에 "Score : 0" 형태로 표시한다.
        }
    }

    public void OnPlayerDead()      //플레이어가 사망할때
    {
        isGameOver = true;             //사망 Flag 활성화
        gameOverUI.SetActive(true);     //UI 활성화
    }
}

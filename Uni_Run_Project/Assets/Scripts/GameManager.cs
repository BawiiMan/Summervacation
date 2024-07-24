using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;     //�̱����� �Ҵ��� ���� ����

    public bool isGameOver = false;     //���ӿ��� ����
    public Text scoreText;              //������ ����� UI�ؽ�Ʈ\
    public GameObject gameOverUI;       //���ӿ����� Ȱ��ȭ�� UI ���� ������Ʈ

    private int score = 0;          //���� ����

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Scene�� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�!");           //��� â�� ����ְ�
            Destroy(gameObject);                                                        //�ڽ��� �����Ѵ�.
        }
    }
    void Update()
    {
        if(isGameOver && Input.GetMouseButtonDown(0))               //GameOver�� �ǰ� ���콺 ���� ��ư�� Ŭ���ϸ�
        {
            //SceneManager.GetActiveScene().name ���� �÷����ϰ� �ִ� ���� Ȱ��ȭ�� Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);     //LoadScene(Name)�� NameScene�� �ҷ��´�.
        }
    }

    public void AddScore(int newScore)      //���ھ ���ϰ� UI�� �ݿ��Ѵ�.
    {
        //���� �������°� �ƴ϶��
        if(!isGameOver)
        {
            score += newScore;      //���� ����
            scoreText.text = "Score : " + score;        //�ؽ�Ʈ�� "Score : 0" ���·� ǥ���Ѵ�.
        }
    }

    public void OnPlayerDead()      //�÷��̾ ����Ҷ�
    {
        isGameOver = true;             //��� Flag Ȱ��ȭ
        gameOverUI.SetActive(true);     //UI Ȱ��ȭ
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;           //생성할 발판의 원본 프리팹
    public int count = 3;                       //생성할 발판 수

    public float timeBetSpawnMin = 1.25f;       //다음 배치까지의 시간 간격 최소
    public float timeBetSpawnMax = 2.25f;       //다음 배치까지의 시간 간격 최대
    private float timeBetSpawn;                 //다음 배치까지의 시간 간격

    public float yMin = -3.5f;                  //배치할 위치의 최소 y값
    public float yMax = 1.5f;                   //배치할 위치의 최대 y값
    private float xPos = 20f;                   //배치할 위치의 x값
    private GameObject[] platforms;              //미리 생성한 발판들
    private int currentIndex = 0;               //사용할 현재 순번의 발판

    //초반에 생성한 발판을 화면 밖에 숨겨둘 위치
    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawnTime;                //마지막 배치 시점
    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            //platformPrefab 원본으로 샐 발판을 poolPosition 위치에 복제 생성
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }

        //마지막 배치 시점 초기화
        lastSpawnTime = 0;
        //다음번 배치까지의 시간을 초기화
        timeBetSpawn = 0;
    }

    void Update()
    {
        if(GameManager.Instance.isGameOver)     //게임오버 상태에서는 동작하지 않음
        {
            return;
        }

        //마지막 배치 시점에서 timeBEtSpawn 이상 시간이 흘렀다면
        if(Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(yMin, yMax);
            float yPos = Random.Range(yMin, yMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            currentIndex++;

            if(currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}

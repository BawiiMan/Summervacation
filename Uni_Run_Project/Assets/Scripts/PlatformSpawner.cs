using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;           //������ ������ ���� ������
    public int count = 3;                       //������ ���� ��

    public float timeBetSpawnMin = 1.25f;       //���� ��ġ������ �ð� ���� �ּ�
    public float timeBetSpawnMax = 2.25f;       //���� ��ġ������ �ð� ���� �ִ�
    private float timeBetSpawn;                 //���� ��ġ������ �ð� ����

    public float yMin = -3.5f;                  //��ġ�� ��ġ�� �ּ� y��
    public float yMax = 1.5f;                   //��ġ�� ��ġ�� �ִ� y��
    private float xPos = 20f;                   //��ġ�� ��ġ�� x��
    private GameObject[] platforms;              //�̸� ������ ���ǵ�
    private int currentIndex = 0;               //����� ���� ������ ����

    //�ʹݿ� ������ ������ ȭ�� �ۿ� ���ܵ� ��ġ
    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawnTime;                //������ ��ġ ����
    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            //platformPrefab �������� �� ������ poolPosition ��ġ�� ���� ����
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }

        //������ ��ġ ���� �ʱ�ȭ
        lastSpawnTime = 0;
        //������ ��ġ������ �ð��� �ʱ�ȭ
        timeBetSpawn = 0;
    }

    void Update()
    {
        if(GameManager.Instance.isGameOver)     //���ӿ��� ���¿����� �������� ����
        {
            return;
        }

        //������ ��ġ �������� timeBEtSpawn �̻� �ð��� �귶�ٸ�
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

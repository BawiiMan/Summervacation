using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefabs;        //������ ź���� ���� ������
    public float spawnRateMin = 0.5f;       //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f;         //�ִ� ���� �ֱ�

    private Transform target;               //�߻��� ���
    private float spawnRate;               //���� �ֱ�
    private float timeAfterSpawn;             //�ֱ� ���� �������� ���� �ð� 'Ÿ�̸�'
    void Start()
    {
        //�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0.0f;
        //ź�� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //[Scene���� ã�´�.]PlayerController ������Ʈ ���� ���� ������Ʈ�� ã�Ƽ� ���� ������� ����
        target = FindObjectOfType<PlayerController>().transform;
    }

    
    void Update()
    {
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        //�ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0;     //������ �ð��� ����

            //BulletPrefabs�� �������� transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);

            bullet.transform.LookAt(target);        //������ bullet ���� ������Ʈ�� ���� ������ target ���ϵ��� ȸ��

            //������ ź�� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCube : MonoBehaviour
{
    public GameObject sampleCubePrefab;
    GameObject[] sampleCube = new GameObject[512];          //샘플 큐브 배열
    public float maxScale = 1000;
    void Start()
    {
        for (int i = 0; i < sampleCube.Length; i++)
        {
            GameObject temp = GameObject.Instantiate(sampleCubePrefab);     //큐브 프리팹 생성
            temp.transform.position = this.transform.position;              //큐브 초기 위치
            temp.transform.parent = this.transform;                         //큐브 부모 설정
            temp.name = "Cube" + i.ToString("000");                         //큐브 이름 설정
            this.transform.eulerAngles = new Vector3(0, -0.73125f * i, 0);      //360 / 512 값
            temp.transform.position = Vector3.forward * 100;
            sampleCube[i] = temp;
        }
    }

    void Update()
    {
        for (int i = 0; i < sampleCube.Length; i++)
        {
            if (sampleCube[i] != null)
            {
                sampleCube[i].transform.localScale
                    = new Vector3(10, (AudioPeer.samples[i] * maxScale) + 2, 10) * 0.1f;
            }
        }

    }
}

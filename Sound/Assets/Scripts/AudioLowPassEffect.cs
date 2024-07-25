using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] //����� �ҽ� ������Ʈ�� �ݵ�� �ʿ��ϴ�.

public class AudioLowPassEffect : MonoBehaviour
{
    AudioSource audioSource;

    //�� ���� ���ļ�
    public float cutoffFrequency = 500.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        AudioLowPassFilter lowPassFilter = gameObject.AddComponent<AudioLowPassFilter>();
        lowPassFilter.cutoffFrequency = cutoffFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

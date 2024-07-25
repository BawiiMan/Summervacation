using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))] //����� �ҽ� ������Ʈ�� �ݵ�� �ʿ��ϴ�.

public class AudioHighPassEffect : MonoBehaviour
{
    AudioSource audioSource;

    public float cutoffFrequency = 500.0f;
    // Start is called before the first frame update
    void Start()
    {
       audioSource = GetComponent<AudioSource>();

        AudioHighPassFilter highPassFilter = gameObject.AddComponent<AudioHighPassFilter>();
        highPassFilter.cutoffFrequency = cutoffFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))] //오디오 소스 컴포넌트가 반드시 필요하다.

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

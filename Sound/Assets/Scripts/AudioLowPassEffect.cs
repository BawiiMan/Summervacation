using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] //오디오 소스 컴포넌트가 반드시 필요하다.

public class AudioLowPassEffect : MonoBehaviour
{
    AudioSource audioSource;

    //컷 오프 주파수
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

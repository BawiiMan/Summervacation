using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] //오디오 소스 컴포넌트가 반드시 필요하다.
public class AudioEchoEffect : MonoBehaviour
{
    AudioSource audioSource;
    public float delay = 500.0f;
    public float delayRatio = 0.5f;
    void Start()
    // Start is called before the first frame update
    {
        audioSource = GetComponent<AudioSource>();

        //AudioEchoFilter 컴포넌트를 추가하고 설정
        AudioEchoFilter echoFilter = gameObject.AddComponent<AudioEchoFilter>();
        echoFilter.delay = delay;
        echoFilter.decayRatio = delayRatio;
    }
}

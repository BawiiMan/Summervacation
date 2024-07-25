using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))] //오디오 소스 컴포넌트가 반드시 필요하다.

public class AudioReverbEffect : MonoBehaviour
{
    AudioSource audioSource;            //AudioSource 컴포넌트를 저장할 변수

    //리버브 프리셋 (다양한 환경에 대한 사전 설정)
    public AudioReverbPreset reverbPreset = AudioReverbPreset.Cave;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //AudioReverbFilter 설정
        AudioReverbFilter reverbFilter = gameObject.AddComponent<AudioReverbFilter>();
        reverbFilter.reverbPreset = reverbPreset;       //선택한 리버브 프리셋 설정
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

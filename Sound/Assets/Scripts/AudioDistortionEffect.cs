using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] //오디오 소스 컴포넌트가 반드시 필요하다.

public class AudioDistortionEffect : MonoBehaviour
{
    AudioSource audioSource;

    public float distortionLevel = 0.5f;                //디스토션 레벨(0.0에서 1.0) 사이
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        AudioDistortionFilter distortionFilter = gameObject.AddComponent<AudioDistortionFilter>();
        distortionFilter.distortionLevel = distortionLevel;
    }

}

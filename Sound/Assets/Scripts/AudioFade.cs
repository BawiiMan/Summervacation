using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFade : MonoBehaviour
{
    AudioSource audioSource;

    public float fadeDuration = 1.0f;               //페이드 인/아웃 지속 시간

    private bool isFadingIn = false;                //페이드 인 상태 확인
    private bool isFadingOut = false;
    private float fadeTimer = 0.0f;                 //페이드 타이머

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(isFadingIn)
        {
            fadeTimer += Time.deltaTime;
            audioSource.volume = Mathf.Clamp01(fadeTimer / fadeDuration);

            if (audioSource.volume >= 1.0f)
            {
                isFadingIn = false;
                fadeTimer = 0.0f;
            }
        }
        if(isFadingOut)
        {
            fadeTimer += Time.deltaTime;        //타이머 증가
            audioSource.volume = Mathf.Clamp01(1.0f - (fadeTimer / fadeDuration));

            if (audioSource.volume <= 0.0f) //완료되면 초기화
            {
                isFadingOut = false;
                fadeTimer = 0.0f;
                audioSource.Stop();
            }
        }
    }

    public void StartFadeIn()
    {
        isFadingIn = true;
        isFadingOut = false;
        fadeTimer = 0.0f;
        audioSource.Play();
    }

    public void StartFadeOut()
    {
        isFadingOut = true;
        isFadingIn = false;
        fadeTimer = 0.0f;
    }
}

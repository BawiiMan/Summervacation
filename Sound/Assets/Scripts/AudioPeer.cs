using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] //오디오 소스 컴포넌트가 반드시 필요하다.

public class AudioPeer : MonoBehaviour
{
    AudioSource audioSource;

    public static float[] samples = new float[512];     //FFT로 얻은 스팩트럼 데이터 샘플
    public static float[] freqBand = new float[8];      //주파수 대역
    public static float[] bandBuffet = new float[8];    //주파수 대역 버퍼
    float[] bufferDecreas = new float[8];               //버퍼 감소 속도

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrumAudioSource();   //오디오 스펙트럼 데이터를 가져온다.
        MakeFrequencyBand();
        BandBuffer();
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBand()            //주파수 대역을 만드는 함수
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if(i == 7)      //마지막 주파수 대역은 2개의 샘플로 추가로 사용
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            //주파수 대역 값을 설정(시각적으로 더 잘 보이도록 10을 곱함)
            freqBand[i] = average * 10;
        }
    }

    void BandBuffer()
    {
        for(int i = 0; i < 8; i++)
        {
            //주파수 대역이 버퍼보다 크면 버퍼를 주파수 대역 값으로 설정
            if (freqBand[i] > bandBuffet[i])
            {
                bandBuffet[i] = freqBand[i];
                bufferDecreas[i] = 0.005f;
            }

            //주파수 대역이 버퍼보다 작으면 버퍼를 감소
            if(freqBand[i] < bandBuffet[i])
            {
                bandBuffet[i] -= bufferDecreas[i];
                bufferDecreas[i] *= 1.2f;

            }
        }

    }
}

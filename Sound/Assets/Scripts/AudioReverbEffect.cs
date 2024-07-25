using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))] //����� �ҽ� ������Ʈ�� �ݵ�� �ʿ��ϴ�.

public class AudioReverbEffect : MonoBehaviour
{
    AudioSource audioSource;            //AudioSource ������Ʈ�� ������ ����

    //������ ������ (�پ��� ȯ�濡 ���� ���� ����)
    public AudioReverbPreset reverbPreset = AudioReverbPreset.Cave;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //AudioReverbFilter ����
        AudioReverbFilter reverbFilter = gameObject.AddComponent<AudioReverbFilter>();
        reverbFilter.reverbPreset = reverbPreset;       //������ ������ ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

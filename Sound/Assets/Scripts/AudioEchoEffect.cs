using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] //����� �ҽ� ������Ʈ�� �ݵ�� �ʿ��ϴ�.
public class AudioEchoEffect : MonoBehaviour
{
    AudioSource audioSource;
    public float delay = 500.0f;
    public float delayRatio = 0.5f;
    void Start()
    // Start is called before the first frame update
    {
        audioSource = GetComponent<AudioSource>();

        //AudioEchoFilter ������Ʈ�� �߰��ϰ� ����
        AudioEchoFilter echoFilter = gameObject.AddComponent<AudioEchoFilter>();
        echoFilter.delay = delay;
        echoFilter.decayRatio = delayRatio;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundClip;                //MP3, WAV
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();       //����� �ҽ��� ���δ�.
        audioSource.clip = backgroundClip;                          //Ŭ���� �Ҵ��Ѵ�.
        audioSource.loop = true;                                    //�ݺ� Ŭ���̶� �����Ѵ�.
        audioSource.Play();                                         //���� ���
    }
}

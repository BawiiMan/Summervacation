using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioParam : MonoBehaviour
{

    public int band;                            //주파수 대역 설정 (0 ~7)
    public float startScale;                    //시작 스케일
    public float scaleMultiplier;

    private Vector3 initalPosition;
    public bool useBuffer;
    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.position;        //시작할때의 위치값을 저장한다.
    }

    // Update is called once per frame
    void Update()
    {
        float newYScale = 0;
        if(!useBuffer)
        {
            newYScale = (AudioPeer.freqBand[band] * scaleMultiplier) + startScale;
        }
        if (useBuffer)
        {
            newYScale = (AudioPeer.bandBuffet[band] * scaleMultiplier) + startScale;
        }
        transform.localScale = new Vector3(transform.localScale.x, newYScale, transform.localScale.z);
        transform.position = new Vector3(transform.position.x, initalPosition.y + (newYScale/2), transform.position.z);

    }
}

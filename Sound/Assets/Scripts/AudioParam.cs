using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioParam : MonoBehaviour
{

    public int band;                            //���ļ� �뿪 ���� (0 ~7)
    public float startScale;                    //���� ������
    public float scaleMultiplier;

    private Vector3 initalPosition;
    public bool useBuffer;
    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.position;        //�����Ҷ��� ��ġ���� �����Ѵ�.
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

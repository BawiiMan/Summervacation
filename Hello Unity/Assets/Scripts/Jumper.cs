using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    public Rigidbody myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody.AddForce(0, 500, 0);            //y축으로 500의 힘만큼 가한다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

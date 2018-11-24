using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCam : MonoBehaviour
{
    public int sensitivityX = 5;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(0, Input.GetAxis("Horizontal") * sensitivityX, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {
    public float walkSpeed = 10;
    public float rotationSpeed = 5.0f;
    public float sensitivityX = 5f;
    float walkVerticle;
    float walkHorizontal;

	// Use this for initialization
	void Start () {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
	
	// Update is called once per frame
	void Update () {
        walkVerticle = Input.GetAxis("Vertical") * walkSpeed;
        walkHorizontal = Input.GetAxis("Horizontal") * walkSpeed;
        walkVerticle *= Time.deltaTime;
        walkHorizontal *= Time.deltaTime;
    }
}

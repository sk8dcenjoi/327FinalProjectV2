using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Controller : MonoBehaviour
{
    public GameObject Cam;
    public float WalkSpeed = 10;
    public float RotationsSpeed = 5.0f;
    public float sensitivityX = 5f;
    float p_WalkLR;
    float p_WalkFB;


    void Start()
    {
        Cam = GameObject.FindGameObjectWithTag("MainCamera");
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void FixedUpdate()
    {
        
            float lh = Input.GetAxisRaw("Horizontal");


            var newRotation = new Vector3(Cam.transform.eulerAngles.x, Cam.transform.eulerAngles.y, transform.eulerAngles.z);


            if (lh != 0f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newRotation), RotationsSpeed * sensitivityX * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                this.GetComponent<Rigidbody>().MoveRotation(transform.rotation);
            }

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * WalkSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * WalkSpeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * WalkSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * WalkSpeed * Time.deltaTime);

        }

        //this.RotationsSpeed
        /*if (Input.GetKey(KeyCode.Space))
              {transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
              Debug.Log("jumped");

       }*/


        /*        p_WalkFB = Input.GetAxis("Vertical") * WalkSpeed;
                /* This will create a variable based on the "Vertical" axis in 
                 * conjunction to the the walking speed variable established earlier. 
                 * This will allow the Player to move forwards and backwards.

                p_WalkLR = Input.GetAxis("Horizontal") * WalkSpeed;
                /* This will create a variable based on the "Horizontal" axis in 
                conjunction to the the walking speed variable established earlier. 
                    This will allow the Player to move left and right.

                p_WalkFB *= Time.deltaTime;
                p_WalkLR *= Time.deltaTime;
                /* This will ensure that the two variables will function in accordance 
                to real time instead of frames.
                transform.Translate(p_WalkLR, 0, p_WalkFB);

                gameObject.transform.Rotate(0, Input.GetAxis("Vertical") * sensitivityX, 0);

                //Mathf.Clamp(rotX, clampAngleMin, clampAngleMax);


                Quaternion bootyTurnAngleY =
                         Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationsSpeed, Vector3.left);
                bootyTurnAngleY = GameObject.FindGameObjectWithTag("PlayerTorso").transform.rotation;


                this.gameObject.transform.Rotate(0, Input.GetAxis("Horizontal") * sensitivityX, 0);*/


    }
}
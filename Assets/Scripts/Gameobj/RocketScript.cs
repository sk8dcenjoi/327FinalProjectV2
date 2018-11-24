using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {

    public float Rspeed = 20.0f;
    public float Rlife = 5.0f;


    // Use this for initialization
    void Start () {
       Invoke("Kill", Rlife);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Rspeed * Time.deltaTime;


       /*void OnCollisionEnter(Collision collision)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal, Color.white);
            }
        }
        */

    }


    void OnTriggerEnter(Collider col)
    {
        Kill();
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}

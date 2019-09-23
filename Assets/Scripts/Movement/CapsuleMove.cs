using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMove : MonoBehaviour
{
    public Rigidbody rb;
    public float ForwardForce = 50f;
    public float SideForce = 30f;
    Vector3 tilt;
    // Start is called before the first frame update
    void Start()
    {
        tilt = new Vector3(0,0,20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.AddForce(0,0,ForwardForce * Time.deltaTime);

        if(Input.GetKey("d"))
        {
            rb.AddForce(SideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
           Quaternion deltaRotation = Quaternion.Euler(-tilt * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);

        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-SideForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
            Quaternion deltaRotation = Quaternion.Euler(tilt * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }


    }
}

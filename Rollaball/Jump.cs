using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    Vector3 position;
    public float JumpPower;
    bool isJump;
    GameObject Floor;
    //bool onFloor;
    // Start is called before the first frame update
    void Awake()
    {
        isJump = false;
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;

            rb.AddForce(Vector3.up * JumpPower);

        }
        

    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            isJump = false;
        }
    }
 
}

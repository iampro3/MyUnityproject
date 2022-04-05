using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private float speed = 3f;

    //Moves this GameObject 2 units a second in the forward direction
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        speed = speed * -1;
    }
}
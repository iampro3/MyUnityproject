using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public GameObject player;
    Transform playerTransform;
    Vector3 Offset;
    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

            Offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset;
        
    }
}


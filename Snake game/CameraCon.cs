using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public Transform target; 

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;   


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y+4, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
       



    }
}

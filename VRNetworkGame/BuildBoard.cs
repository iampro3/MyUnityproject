using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBoard : MonoBehaviour
{
    public Transform canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canvas.forward = Camera.main.transform.forward;     
    }
}

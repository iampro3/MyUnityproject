using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backg : MonoBehaviour
{
    public Material BackMat;
    public float scrollspeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.up;
        BackMat.mainTextureOffset += direction * scrollspeed * Time.deltaTime;
    }
}

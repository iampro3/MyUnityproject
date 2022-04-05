using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bam : MonoBehaviour
{
    float eTime = 0; //
    float destroytime = 0; //
    bool timer = false;  //
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
        timer = true; //
        //StartCoroutine("destroyObject");
    }

    void Start()
    {
        // Shoot(new Vector3(0, 150, 2000));
    }
   private void Update()
    {
        if (timer) //
        {
            eTime += Time.deltaTime; //
        }
        if (eTime > destroytime) //
        {
            Destroy(this.gameObject);// 밤송이가 사라지게
        }
    }
}




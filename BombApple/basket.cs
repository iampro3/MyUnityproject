using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    //public AudioClip appleSE;
    //public AudioClip bombSE;
    //AudioSource aud;
    GameObject director;

    void Start()
    {
        this.director = GameObject.Find("Director");
        //this.aud = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "apple")
        {
            this.director.GetComponent<Director>().GetApple();
            Debug.Log("Tag=apple");
            //this.aud.PlayOneShot(this.appleSE);
        }
        else
        {
            this.director.GetComponent<Director>().GetBomb();
            Debug.Log("Tag=bomb");
            //this.aud.PlayOneShot(this.bombSE);
        }
        Destroy(other.gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APTController : MonoBehaviour
{
    //public GameObject[] BedRoom small wall;
    //public Color32[] colors;
    //Material[] aptMats;

    public GameObject Collider;
    public float rotSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //aptMats = new Material[BedRoom small wall.Length];
        
        //for(int i = 0; i<carMats.Length; i++)
         //   { 
        //    aptMats[i] = BedRoom small wall[i].GetComponent<MeshRenderer>().material;
        //}
       // colors[0] = aptMats[0].color;
    }

    //public void ChangeColor(int num)
    //{
     //   for (int i = 0; i < aptMats.Length; i++)
     //   {
     //       aptMats[i].color = colors[num];
     //   }
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Ray ray = new Ray(Camera.main.transform.position,
                                    Camera.main.transform.forward);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, 1 << 8))
                {
                    Vector3 deltaPos = touch.deltaPosition;
                    transform.Rotate(transform.up,
                                     deltaPos.x * -1.0f * rotSpeed);

                }
            }
        }
    }
}

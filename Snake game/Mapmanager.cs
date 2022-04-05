using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapmanager : MonoBehaviour
{
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        mapcreate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void mapcreate()
    {
        GameObject parent = new GameObject("parent");       

        for (int x = 0; x<100; x++)
        {
            for(int z = 0; z<100; z++)
            {
                GameObject a = Instantiate(map);
                a.name = "x:" + x+"z";
                a.transform.position = new Vector3(x, 0 ,z);

                int i = z;
                //int b = x ;
                if (z % 2 == 0 && x % 2 == 0)  // %는 나머지값이다. 
                {
                    a.GetComponent<MeshRenderer>().material.color = new Color32(0, 0, 0, 255);

                }
                else if(x % 2 == 1 && z % 2 == 1)
                {
                    a.GetComponent<MeshRenderer>().material.color = new Color32(0 , 0, 0, 255);

                    
                }
                a.transform.SetParent(parent.transform); // 선언과 결과는 for 문 밖으로 빼야한다.
            }            
        }
        parent.transform.position = new Vector3(-50, 0, -50);
    }
}

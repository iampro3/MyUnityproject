using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject bamsongiPrefab;
    public GameObject mainCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab) as GameObject;


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            bamsongi.GetComponent<bam>().Shoot(worldDir.normalized * 2000);
        }
    }
}

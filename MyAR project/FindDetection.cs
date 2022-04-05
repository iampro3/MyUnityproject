using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using Unity.Collections;
using UnityEngine.UI;

public class FindDetection : MonoBehaviour
{
    public ARFaceManager afm;
    public GameObject smallCube;
    public Text vertexIndex;
    List<GameObject> faceCubes = new List<GameObject>();
    ARCoreFaceSubsystem subSys;

    NativeArray<ARCoreFaceRegionData> regionData;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i <3; i++)
        {
            GameObject go = Instantiate(smallCube);
            faceCubes.Add(go);
            go.SetActive(false);

        }
        //afm.facesChanged += OnDetectThreePoints;
        afm.facesChanged += OnDetectFaceAll;
        subSys = (ARCoreFaceSubsystem)afm.subsystem;

        //void OnDetectThreePoints(ARFacesChangedEventArgs args)
       // {
          //  if (args.updated.Count > 0)
          //  {
          //      subSys.GetRegionPoses(args.updated[0].trackableId, Allocator.Persistent, ref regionData);

          //      for (int i = 0; i < regionData.Length; i++)
         //       {
         //           faceCubes[i].transform.position = regionData[i].pose.position;
         //           faceCubes[i].transform.rotation = regionData[i].pose.rotation;
         //           faceCubes[i].SetActive(true);
         //       }
         //   }
         //   else if(args.removed.Count > 0)
          //  {
          //      for (int i = 0; i < regionData.Length; i++)
          //      {
          //          faceCubes[i].SetActive(false);
          //      }
          //  }
      //  }

        void OnDetectFaceAll(ARFacesChangedEventArgs args)
        {
            if (args.updated.Count > 0)
            {
                int num = int.Parse(vertexIndex.text);
                Vector3 verPosition = args.updated[0].vertices[num];

                verPosition = args.updated[0].transform.TransformPoint(verPosition);

                faceCubes[0].SetActive(true);
                faceCubes[0].transform.position = verPosition;
            }

            else if (args.removed.Count > 0)
            {
                faceCubes[0].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

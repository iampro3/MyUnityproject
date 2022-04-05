using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultipleImageTracker : MonoBehaviour
{
    ARTrackedImageManager imageManager;


    // Start is called before the first frame update
    void Start()
    {
        imageManager = GetComponent<ARTrackedImageManager>();
        StartCoroutine(TurnOnImageTracking());
        //imageManager.trackedImagesChanged += OntrackedImage;
    }

    IEnumerator TurnOnImageTracking()
    {
       imageManager.enabled = false;
    
      while(!GPSManager.instance.receiveGPS)
    {
        yield return null;
    }
        imageManager.enabled = true;
        imageManager.trackedImagesChanged += OntrackedImage;
    }

    public void OntrackedImage(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage trackedImage in args.added)
        {

           // string imageName = trackedImage.referenceImage.name;
            //GameObject imagePrefab = Resources.Load<GameObject>(imageName);

            //if (imagePrefab != null)
            //{
            //    GameObject go = Instantiate(imagePrefab, trackedImage.transform.position,
            //                                    trackedImage.transform.rotation);
            //    go.transform.SetParent(trackedImage.transform);
           // }
            Vector2 myPos = new Vector2(GPSManager.instance.latitude,
                                          GPSManager.instance.longitude);
            StartCoroutine(DBmanager.instance.LoadData(myPos, trackedImage.transform));
        }
    
        foreach (ARTrackedImage trackedImage in args.updated)
        {
            if (trackedImage.transform.childCount > 0)
            {
                trackedImage.transform.GetChild(0).position = trackedImage.transform.position;
                trackedImage.transform.GetChild(0).rotation = trackedImage.transform.rotation;
                trackedImage.transform.GetChild(0).localScale = trackedImage.transform.localScale;
            }
        }
    }

}



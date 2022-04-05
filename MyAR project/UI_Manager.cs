using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Material[] faceMats;
    public ARFaceManager faceManager;
    public Text indexText;

    int vertNum = 0;
    int verCount = 468;
    // Start is called before the first frame update
    public void ToggleMaskImage()
    {
        indexText.text = vertNum.ToString();
        foreach (ARFace face in faceManager.trackables)
        {
            if (face.trackingState == TrackingState.Tracking)
            {
                face.gameObject.SetActive(!face.gameObject.activeSelf);
            }
        }
    }

    public void SwitchFaceMaterial(int num)
    {
        foreach (ARFace face in faceManager.trackables)
        {
            MeshRenderer mr = face.GetComponent<MeshRenderer>();
            mr.material = faceMats[num];
        }
    }

    public void IndexIncreasd()
    {
        int number = Mathf.Min(++vertNum, verCount - 1);
        indexText.text = number.ToString();
    }

    public void IndexDecrease()
    {
        int number = Mathf.Max(--vertNum, 0);
        indexText.text = number.ToString();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

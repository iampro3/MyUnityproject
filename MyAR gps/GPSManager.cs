using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class GPSManager : MonoBehaviour
{
    public static GPSManager instance;

    public Text latitude_text;
    public Text longitude_text;

    public float latitude = 0;
    public float longitude = 0;

    public float maxWaitTime = 10.0f;
    float waitTime = 0;
    public float resendTime = 1.0f;

    public bool receiveGPS = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GPS_On());
    }

    public IEnumerator GPS_On()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);

            while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                yield return null;
            }

            if (!Input.location.isEnabledByUser)
            {
                latitude_text.text = "GPS Off";
                longitude_text.text = "GPS Off";
                yield break;

            }
                Input.location.Start();
                while (Input.location.status == LocationServiceStatus.Initializing
                && waitTime < maxWaitTime)
                              
                {
                    yield return new WaitForSeconds(1.0f);
                    waitTime++;
                }
                
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                latitude_text.text = "��ġ���� ���Ž���";
                longitude_text.text = "��ġ���� ���Ž���";
            }

            if (waitTime >= maxWaitTime)
            {
                latitude_text.text = "���� ���ð� �ʰ�";
                longitude_text.text = "���� ���ð� �ʰ�";
            }
            LocationInfo li = Input.location.lastData;
            latitude = li.latitude;
            longitude = li.longitude;
            latitude_text.text = "����:" + latitude.ToString(); 
            longitude_text.text = "�浵:" + longitude.ToString();

            receiveGPS = true;

            while (receiveGPS)
            {
                yield return new WaitForSeconds(resendTime);

                li = Input.location.lastData;
                latitude = li.latitude;
                longitude = li.longitude;
                latitude_text.text = "����:" + latitude.ToString();
                longitude_text.text = "�浵:" + longitude.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

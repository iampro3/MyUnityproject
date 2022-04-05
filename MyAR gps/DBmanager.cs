
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System;
using System.Threading.Tasks;

public class DBmanager : MonoBehaviour
{
    public static DBmanager instance;
    public string databaseUrl = "https://myargps-default-rtdb.asia-southeast1.firebasedatabase.app/";
    Vector2 currentPos;
    string objectName = "";
    string currentKey = "";
    bool isSearch = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl = new Uri(databaseUrl);
        //SaveData(); // 저장함수를 실행한다.
    }

    void SaveData()
    {
        ImageGPSData data1 = new ImageGPSData("Cat", 37.50432f, 127.1034f, false);
        ImageGPSData data2 = new ImageGPSData("Scar", 37.50430f, 127.103f, false);

        string jsonCat = JsonUtility.ToJson(data1);
        string jsonSCar = JsonUtility.ToJson(data2);

    DatabaseReference refData = FirebaseDatabase.DefaultInstance.RootReference;

        refData.Child("Markers").Child("Data1").SetRawJsonValueAsync(jsonCat);
        refData.Child("Markers").Child("Data2").SetRawJsonValueAsync(jsonSCar);

        print(jsonCat);
        print(jsonSCar);
        print("데이터 저장완료!");
}

    public class ImageGPSData
    {
        public string name;
        public float latitude;
        public float longitude;
        public bool isCaptured = false;



        public ImageGPSData(string objName, float lat, float lon, bool captured)
        {
            name = objName;
            latitude = lat;
            longitude = lon;
            isCaptured = captured;
        }
    }

    public IEnumerator LoadData(Vector2 myPos, Transform trackedImage)
    {
        currentPos = myPos;

        DatabaseReference refData = FirebaseDatabase.DefaultInstance.GetReference("Markers");
        isSearch = true;
        refData.GetValueAsync().ContinueWith(LoadFunc);   

    while (isSearch)
    {
        yield return null;
    }

        GameObject imagePrefab = Resources.Load<GameObject>(objectName);
        if(imagePrefab !=null)
        {
            if (trackedImage.transform.childCount < 1)
            {
                GameObject go = Instantiate(imagePrefab, trackedImage.position,
                                                         trackedImage.rotation);
                go.transform.SetParent(trackedImage.transform);
            }
        }
    }

void LoadFunc(Task<DataSnapshot> task)// using System.Threading.Tasks;추가하기
    {
    if (task.IsFaulted)
    {
        Debug.LogError("DB에서 데이터를 가져오는데 실패했습니다.");
    }
    else if (task.IsCanceled)
    {
        Debug.Log("DB에서 데이터를 가져오는 것이 취소 됐습니다.");
    }
    else if(task.IsCompleted)
    {
        DataSnapshot snapShot = task.Result;
        foreach (DataSnapshot data in snapShot.Children)
        {
            string myData = data.GetRawJsonValue();
            ImageGPSData myClassData = JsonUtility.FromJson<ImageGPSData>(myData);

            if (!myClassData.isCaptured)
            {
                Vector2 dataPos = new Vector2(myClassData.latitude, 
                                              myClassData.longitude);
                float distance = Vector2.Distance(currentPos, dataPos);

                    if(distance < 0.001f) 
                {
                    objectName = myClassData.name;
                    currentKey = data.Key;
                }
            }
        }
    }
    isSearch = false;
        
}

    public void UpdateCaptured()
    { 
        string dataPath = "Markers/" + currentKey + "/isCaptured"; // 책이 틀림
        DatabaseReference refData = FirebaseDatabase.DefaultInstance.
                                                             GetReference(dataPath);

        if(refData != null)
        {
            refData.SetValueAsync(true);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

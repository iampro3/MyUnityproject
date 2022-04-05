using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(960, 640, FullScreenMode.Windowed); // 실행화면 해상도를 960x640
        PhotonNetwork.SendRate = 30; // 데이터 송수신빈도 를 초당 30초로 설정
        PhotonNetwork.SerializationRate = 30;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

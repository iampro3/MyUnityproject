using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(960, 640, FullScreenMode.Windowed); // ����ȭ�� �ػ󵵸� 960x640
        PhotonNetwork.SendRate = 30; // ������ �ۼ��ź� �� �ʴ� 30�ʷ� ����
        PhotonNetwork.SerializationRate = 30;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

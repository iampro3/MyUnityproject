using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 
using Photon.Realtime; 



public class ConnManager : MonoBehaviourPunCallbacks

{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = "0.1";
        int num = Random.Range(0, 1000);
        PhotonNetwork.NickName = "Player" + num;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("로비 접속 완료!");
        RoomOptions ro = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 8
        };
        PhotonNetwork.JoinOrCreateRoom("NetText", ro, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("룸 입장!");
        Vector2 originPos = Random.insideUnitCircle * 2.0f;
        PhotonNetwork.Instantiate("Player", new Vector3(originPos.x, 0, originPos.y), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

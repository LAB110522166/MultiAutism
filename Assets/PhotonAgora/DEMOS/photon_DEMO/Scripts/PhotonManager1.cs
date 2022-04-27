using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonManager1 : Photon.PunBehaviour
{
    public static PhotonManager1 instance;
    public static GameObject localPlayer;
    
    void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;

        PhotonNetwork.automaticallySyncScene = true;
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("DEMOPUN_v1.0");
    }

    public void JoinGame()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 10;
        //加入或建立HAPPY Room
        PhotonNetwork.JoinOrCreateRoom("HAPPY Room", options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("您已進入遊戲室");

        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.LoadLevel("GameRoomScene");
        }
    }

    void OnLevelWasLoaded(int levelNumber)
    {
        if (!PhotonNetwork.inRoom) return;
        Debug.Log("我們已進入遊戲場景了,耶~");
        localPlayer = PhotonNetwork.Instantiate(
            "PurePlayer",
            new Vector3(Random.Range(-8.0f, 8.0f), 3f, Random.Range(-4.0f, 4.0f)),
            Quaternion.identity, 0);
    }
}
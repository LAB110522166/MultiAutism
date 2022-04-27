using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonMain : Photon.PunBehaviour
{
    public static PhotonMain instance;
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
        //�[�J�Ϋإ�HAPPY Room
        PhotonNetwork.JoinOrCreateRoom("HAPPY Room3", options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("�z�w�i�J�C����");

        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }

    void OnLevelWasLoaded(int levelNumber)
    {
        if (!PhotonNetwork.inRoom) return;
        Debug.Log("�ڭ̤w�i�J�C�������F,�C~");
        localPlayer = PhotonNetwork.Instantiate(
            "MainPlayer",
            new Vector3(Random.Range(-8.0f, 8.0f), 3f, Random.Range(-4.0f, 4.0f)),
            Quaternion.identity, 0);
    }
}
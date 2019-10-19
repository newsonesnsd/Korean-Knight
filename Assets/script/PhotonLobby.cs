/*using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    RoomInfo[] rooms;

    public GameObject batttleButton;
    public GameObject cancelButton;

    private void Awake()
    {
        lobby = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("player coonect to photon server");
        batttleButton.SetActive(true);
    }

    public void onBattleButtonClick()
    {
        Debug.Log("click batteButton");
        batttleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join a random game but failed");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("click Create");
        int randomRoomName = Random.Range(0, 1000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Join Room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to Create a new Room but failed");
        CreateRoom();
    }

    public void onCancelButtonClick()
    {
        Debug.Log("click cancelButton");
        cancelButton.SetActive(false);
        batttleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}*/

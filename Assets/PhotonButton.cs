using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButton : MonoBehaviour
{
    public InputField createRoomInput, jionRoomInput;

    public void onClickCreaterRoom()
    {
        if (createRoomInput.text.Length >= 1) {
            PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions() { MaxPlayers = 2 }, null);
        }
    }

    public void onClickJionRoom()
    {
        PhotonNetwork.JoinRoom(jionRoomInput.text);
    }

    public void OnJionRoom()
    {
        Debug.Log("We are connect to the room");
    }

}

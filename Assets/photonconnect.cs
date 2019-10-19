using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photonconnect : MonoBehaviour
{
    public string versionName = "0.1";

    public GameObject sectionView1, sectionView2, sectionView3;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();

        Debug.Log("Connect to Photon ....");
        OnConnectToMaster();
    }

    private void OnConnectToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);

        Debug.Log("We are connect to Master");
        OnJionedLobby();
    }

    private void OnJionedLobby()
    {
        sectionView1.SetActive(false);
        sectionView2.SetActive(true);

        Debug.Log("On Jion Lobby");
    }

    private void OnDisconnectedFromPhoton()
    {
        if (sectionView1.active)
            sectionView1.SetActive(false);
        if (sectionView2.active)
            sectionView2.SetActive(false);

        sectionView3.SetActive(true);

        Debug.Log("Disconnect from Photon"); 
    }

}

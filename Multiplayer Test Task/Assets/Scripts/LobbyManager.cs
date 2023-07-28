using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private PlayerRegistration current;
    void Start()
    {
        PhotonNetwork.NickName = current.Name;
        PhotonNetwork.GameVersion = "Demo1";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();

    }
    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }
    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Loading");
    }
}

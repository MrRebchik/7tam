using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private PlayerRegistration current;
    [SerializeField] private TMP_InputField createRoom;
    [SerializeField] private TMP_InputField joinRoom;
    void Start()
    {
        Debug.Log("менеджер запущен");
        PhotonNetwork.NickName = current.Name;
        //PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();

    }
    public void CreateRoom()
    {
        if(createRoom.text != string.Empty)
        {
            PhotonNetwork.CreateRoom(createRoom.text);
        }
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("создана комната с названием " + createRoom.text);
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("подключился к серверу");
    }
    public void JoinRoom()
    {
        if(joinRoom.text != string.Empty)
        {
            PhotonNetwork.JoinRoom(joinRoom.text);
        }
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Loading");
        Debug.Log("подключился игрок " + current.Name);
    }
}

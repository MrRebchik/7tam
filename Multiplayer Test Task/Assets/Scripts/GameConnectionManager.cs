using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConnectionManager : MonoBehaviourPunCallbacks
{
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
}

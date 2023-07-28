using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Transition : MonoBehaviourPunCallbacks
{
    private bool isEnoughPlayers = false;
    void Update()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            isEnoughPlayers = true;
        }
        if (isEnoughPlayers)
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }
}

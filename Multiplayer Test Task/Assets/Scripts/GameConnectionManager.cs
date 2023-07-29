using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConnectionManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;
    private void Start()
    {
        Vector3 pos = new(Random.Range(-10f, 10f), Random.Range(-4f, 4f));
        PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
}

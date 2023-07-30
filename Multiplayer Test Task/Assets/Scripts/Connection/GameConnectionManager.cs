using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameConnectionManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject coin;
    private float timeInterval = 4f;
    private float timeLeft;
    private void Start()
    {
        timeLeft = timeInterval;
        Vector3 pos = new(Random.Range(-10f, 10f), Random.Range(-4f, 4f));
        PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);
        Debug.Log(coin.name);
        Debug.Log(playerPrefab.name);
    }
    private void FixedUpdate()
    {
        Debug.Log(coin.name);
        timeLeft -= Time.deltaTime;
        if (!PhotonNetwork.IsMasterClient) return;
        if(timeLeft <= 0) 
        {
            Vector3 pos = new(Random.Range(-10f, 10f), Random.Range(-4f, 4f));
            PhotonNetwork.Instantiate(coin.name, pos, Quaternion.identity);
            timeLeft = timeInterval;
        }
    }
    public override void OnLeftRoom()
    {
        PlayerPrefs.SetInt("IsRegistered", (int)Session.Registered);
        SceneManager.LoadScene("Lobby");
    }
    public void Fire(GameObject g, Vector3 pos, Quaternion q)
    {
        PhotonNetwork.Instantiate(g.name,pos,q);
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
}

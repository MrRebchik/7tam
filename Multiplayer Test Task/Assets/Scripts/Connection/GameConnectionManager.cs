using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameConnectionManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject endPupUp;
    private float timeInterval = 6f;
    private float timeLeft;
    private int aliveCount;
    private void Start()
    {

        timeLeft = timeInterval;

        Vector3 pos = new(Random.Range(-10f, 10f), Random.Range(-4f, 4f));
        PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);

    }

    private void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (!PhotonNetwork.IsMasterClient) return;
        if(timeLeft <= 0) 
        {
            Vector3 pos = new(Random.Range(-10f, 10f), Random.Range(-4f, 4f));
            PhotonNetwork.Instantiate(coin.name, pos, Quaternion.identity);
            timeLeft = timeInterval;
        }
        if(aliveCount == 1)
        {
            endPupUp.gameObject.SetActive(true);
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

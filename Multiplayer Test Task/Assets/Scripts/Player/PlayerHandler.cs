using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public Image healthBar;
    [SerializeField] public TMP_Text moneyText;
    public int Health { get; private set; }
    public int Money { get; private set; }
    public bool IsAlive { get; private set; }
    void Start()
    {
        Health = 100;
        IsAlive = true;
        Money = 0;
    }

    void FixedUpdate()
    {
        healthBar.transform.localScale = new Vector3((float)Health/100,1,1);
        if (Health <= 0 && IsAlive)
        {
            Dead();
            IsAlive = false;
            Health = 0;
        }
        moneyText.text = "Money:" + Money.ToString();
    }
    public void Dead()
    {
        PhotonNetwork.LeaveRoom();
    }
    public void Damage()
    {
        if(Health > 0)
        {
            Health -= 24;
        }
        else Health = 0;
        
    }
    public void TakeCoin()
    {
        Money++;
    }
    
}

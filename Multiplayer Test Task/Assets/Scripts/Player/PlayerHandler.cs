using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private int Health;
    [SerializeField] private int Money;
    [SerializeField] public GameObject bulletPrefab;
    public bool IsAlive { get; private set; }
    void Start()
    {
        Health = 100;
        IsAlive = true;
        Money = 0;
    }

    void FixedUpdate()
    {
        if (Health <= 0)
        {
            IsAlive = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Health -= 26;
            Debug.Log("урон");
        }
        if(collision.gameObject.CompareTag("Coin"))
        {
            Money++;
        }
    }
}

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviourPunCallbacks
{

    [SerializeField] private PhotonView photonView;
    private Rigidbody2D rigidBody;
    private GameObject _joystick;
    private FixedJoystick joystick;
    private Animator animator;
    private GameObject logic;
    [SerializeField] public PlayerHandler playerHandler;
    [SerializeField] public GameConnectionManager gameConnectionManager;
    [SerializeField] public TMP_Text NickText;
    [SerializeField] public GameObject shotPoint;
    [SerializeField] private GameObject bullet;

    private readonly float moveSpeed = 1.5f;
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        rigidBody = GetComponent<Rigidbody2D>();
        _joystick = GameObject.FindGameObjectWithTag("Joystick");
        joystick = _joystick.GetComponent<FixedJoystick>();
        animator = GetComponent<Animator>();
        logic = GameObject.FindGameObjectWithTag("Logic");
        gameConnectionManager = logic.GetComponent<GameConnectionManager>();
        playerHandler = logic.GetComponent<PlayerHandler>();
        bullet = playerHandler.bulletPrefab;
        NickText.text = photonView.Owner.NickName;
        if (!photonView.IsMine)
        {
            NickText.color = Color.red;
        }
    }

    public void Fire()
    {
        logic = GameObject.FindGameObjectWithTag("Logic");
        gameConnectionManager = logic.GetComponent<GameConnectionManager>();
        playerHandler = logic.GetComponent<PlayerHandler>();
        shotPoint = GameObject.Find("BulletSpawner");
        Debug.Log(shotPoint.transform.rotation);
        gameConnectionManager.Fire(
            bullet,
            shotPoint.transform.position,
            //Quaternion.Euler(shotPoint.transform.rotation.x, shotPoint.transform.rotation.y, shotPoint.transform.rotation.z));
            shotPoint.transform.rotation);
    }
    private void FixedUpdate()
    {
        if (!photonView.IsMine) return;
        if (!playerHandler.IsAlive)
        {
            rigidBody.velocity = Vector2.zero;
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsWalk", false);
            return;
        }

        rigidBody.velocity = new Vector2(-joystick.Horizontal * moveSpeed, -joystick.Vertical * moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, rigidBody.velocity);
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsIdle", false);
        }
        else
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsWalk", false);
        }
    }
}

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PhotonView photonView;
    private Rigidbody2D rigidBody;
    private GameObject _joystick;
    private FixedJoystick joystick;
    private Animator animator;

    private float moveSpeed = 1.5f;
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        rigidBody = GetComponent<Rigidbody2D>();
        _joystick = GameObject.FindGameObjectWithTag("Joystick");
        joystick = _joystick.GetComponent<FixedJoystick>();
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        if (!photonView.IsMine) return;

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

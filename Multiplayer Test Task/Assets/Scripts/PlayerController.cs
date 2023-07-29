using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(-joystick.Horizontal * moveSpeed, -joystick.Vertical * moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            //transform.Rotate(new Vector3(0, 0, Mathf.Atan(rigidbody.velocity.y/ rigidbody.velocity.x)));
            transform.rotation = Quaternion.LookRotation(Vector3.forward, rigidbody.velocity);
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    private float speed = 7;

    [SerializeField]
    private float jumpForce = 7;

    [SerializeField]
    private Transform groundChecker;

    [SerializeField]
    private LayerMask floorLayerMask;

    private bool isGrounded = false;
    private bool jumpedInAir = false;

    internal void AddPoint() {
        Debug.Log("Collected");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void CheckIsGrounded() {
        var hit = Physics2D.Raycast(groundChecker.position, Vector2.down, 0.1f, floorLayerMask);
        if(hit.collider != null) {
            isGrounded = true;
            jumpedInAir = false;
        } else {
            isGrounded = false;
        }
    }

    void Update()
    {
        CheckIsGrounded();

        float xMove = 0;
        float yMove = rb.velocity.y;

        if(Input.GetKey(KeyCode.D)) {
            xMove = speed;
        }
        if (Input.GetKey(KeyCode.A)) {
            xMove = -speed;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) {
            if (isGrounded) {
                yMove = jumpForce;
            } else {
                if(!jumpedInAir) {
                    yMove = jumpForce;
                    jumpedInAir = true;
                }
            }
        }

        rb.velocity = new Vector2(xMove, yMove);
    }
}

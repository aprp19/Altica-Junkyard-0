﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // private void Update()
    // {
    //     moveH = Input.GetAxis("Horizontal") * moveSpeed;
    //     moveV = Input.GetAxis("Vertical") * moveSpeed;
    //     rb.velocity = new Vector2(moveH,moveV);
    // }

    private void FixedUpdate()
    {
        moveH = joystick.Horizontal * moveSpeed;
        moveV = joystick.Vertical * moveSpeed;
        rb.velocity = new Vector2(moveH,moveV);
        
        Vector2 direction = new Vector2(moveH,moveV);
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
    }
}

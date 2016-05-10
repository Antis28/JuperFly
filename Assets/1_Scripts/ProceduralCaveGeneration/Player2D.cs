﻿using UnityEngine;
using System.Collections;

public class Player2D : MonoBehaviour
{

    Rigidbody2D player2Drigidbody;
    Vector2 velosity;

    // Use this for initialization
    void Start()
    {
        player2Drigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        velosity = new Vector2( Input.GetAxisRaw( "Horizontal" ), Input.GetAxisRaw( "Vertical" ) ).normalized * 10;
    }
    void FixedUpdate()
    {
        player2Drigidbody.MovePosition( player2Drigidbody.position + velosity * Time.fixedDeltaTime );
    }
}

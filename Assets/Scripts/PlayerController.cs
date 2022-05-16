using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float _baseSpeed = 20f;
    [SerializeField] private float _boostSpeed = 30f;
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private float _jumpForce = 50f;

    private Rigidbody2D _rigidbody2D;
    private SurfaceEffector2D _surfaceEffector2D;
    
    private bool canMove = true;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }
    
    private void Update()
    {
        if (!canMove) return;

        HandleBoost();
        HandleJump();
        HandleRotation();
    }

    public void DisableControls()
    {
        canMove = false;
    }

    private void HandleBoost()
    {
        _surfaceEffector2D.speed = Input.GetKey(KeyCode.UpArrow) ? _boostSpeed : _baseSpeed;
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump")) 
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            _rigidbody2D.AddTorque(_rotationSpeed);

        else if (Input.GetKey(KeyCode.RightArrow)) 
            _rigidbody2D.AddTorque(-_rotationSpeed);
    }
}
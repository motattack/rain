using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private LayerCheck _groundCheck;
    
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private bool IsGrounded()
    {
        return _groundCheck.IsTouchingLayer;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction.x * _speed, _rigidbody2D.velocity.y);

        var isJumping = _direction.y > 0;
        if (isJumping)
        {
            if (IsGrounded())
            {
                _rigidbody2D.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            }
            else if (_rigidbody2D.velocity.y > 0)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * 0.5f);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private PlayerInput _input;
    private bool _isGrounded;

    public UnityEvent Jumped;
    public UnityEvent Stopped;
    
    private void MoveRight()
    {
        Move(_speed);
    }

    private void MoveLeft()
    {
        Move(-_speed);
    }

    private void Move(float speed)
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            _isGrounded = false;
        }
    }

    private void Awake()
    {
        _isGrounded = true;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _input.MovedLeft.AddListener(MoveLeft);
        _input.MovedRight.AddListener(MoveRight);
        _input.Jumped.AddListener(Jump);
    }

    private void OnDisable()
    {
        _input.MovedLeft.RemoveListener(MoveLeft);
        _input.MovedRight.RemoveListener(MoveRight);
        _input.Jumped.RemoveListener(Jump);
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity.y != 0)
        {
            Jumped?.Invoke();
            _isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_rigidbody2D.velocity.y == 0)
        {
            Stopped?.Invoke();
            _isGrounded = true;
        }
    }
}

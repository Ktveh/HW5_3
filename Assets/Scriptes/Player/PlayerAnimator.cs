using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput), typeof(PlayerMover))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerInput _input;
    private PlayerMover _mover;

    public void Stop()
    {
        _animator.SetBool("Walk", false);
        _animator.SetBool("Jump", false);
    }

    public void MoveLeft()
    {
        Move(true);
    }

    public void MoveRight()
    {
        Move(false);
    }

    public void Move(bool flipX)
    {
        _spriteRenderer.flipX = flipX;
        _animator.SetBool("Walk", true);
    }

    public void Jump()
    {
        _animator.SetBool("Jump", true);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _input = GetComponent<PlayerInput>();
        _mover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _input.MovedLeft.AddListener(MoveLeft);
        _input.MovedRight.AddListener(MoveRight);
        _mover.Stopped.AddListener(Stop);
        _mover.Jumped.AddListener(Jump);
    }

    private void OnDisable()
    {
        _input.MovedLeft.RemoveListener(MoveLeft);
        _input.MovedRight.RemoveListener(MoveRight);
        _mover.Stopped.RemoveListener(Stop);
        _mover.Jumped.RemoveListener(Jump);
    }
}

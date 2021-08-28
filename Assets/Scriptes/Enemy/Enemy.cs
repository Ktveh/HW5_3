using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _leftBoard;
    [SerializeField] private GameObject _rightBoard;

    private EnemyMover _mover;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _mover = GetComponent<EnemyMover>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _mover.SetTarget(_rightBoard.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _rightBoard)
        {
            _mover.SetTarget(_leftBoard.transform); 
            _spriteRenderer.flipX = true;
        }
        else if (collision.gameObject == _leftBoard)
        {
            _mover.SetTarget(_rightBoard.transform);
            _spriteRenderer.flipX = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
    
    private void Update()
    {
        Move();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private int _countCoins;
    [SerializeField] private float _distanceBetweenCoints;

    private void Start()
    {
        Create();
    }

    private void Create()
    {
        for (int i = 0; i < _countCoins; i++)
        {
            var newPosition = new Vector2(transform.position.x + _distanceBetweenCoints * i, transform.position.y);
            Instantiate(_coin, newPosition, Quaternion.identity);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private float _speed;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement movement))
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (_movement.Direction.z > 0)
                {
                    _movement.Gravity = _speed;
                }
            }).AddTo(_disposable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement movement))
        {
            _movement.Gravity = -9.8f;
            _disposable.Clear();
        }
    }
}
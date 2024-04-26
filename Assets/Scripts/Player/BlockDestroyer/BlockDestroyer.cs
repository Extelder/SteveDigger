using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;

public class BlockDestroyer : MonoBehaviour
{
    [SerializeField] private PlayerAnimatorController _animatorController;

    [FormerlySerializedAs("_destroyRate")] [field: SerializeField]
    public float DestroyRate = 1.2f;

    [SerializeField] private float _delay;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private bool _delaying;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Block>(out Block block))
        {
            _delay = DestroyRate;
            _delaying = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Block>(out Block block))
        {
            if (_delay <= 0)
            {
                block.DestroyBlock();
                _delay = DestroyRate;
                _delaying = false;
            }
            else if (_delaying == false)
            {
                _delaying = true;
                Observable.EveryUpdate().Subscribe(_ =>
                {
                    _delay -= Time.deltaTime;
                    if (_delay <= 0)
                    {
                        _delay = 0;
                        _disposable.Clear();
                    }
                }).AddTo(_disposable);
            }

            Debug.Log(block.gameObject.name);
            _animatorController.Attack();
        }
    }
}
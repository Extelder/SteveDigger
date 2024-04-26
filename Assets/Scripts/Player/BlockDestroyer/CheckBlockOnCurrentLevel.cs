using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class CheckBlockOnCurrentLevel : MonoBehaviour
{
    [SerializeField] private BlockDestroyer _downBlockDestroyer;

    private CompositeDisposable _disposable = new CompositeDisposable();

    [SerializeField] private List<Block> Blocks = new List<Block>();

    private int _blockInLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Block>(out Block block))
        {
            _downBlockDestroyer.gameObject.SetActive(false);
            if (!Blocks.Contains(block))
            {
                Blocks.Add(block);
                _blockInLevel++;
                block.gameObject.OnDestroyAsObservable().Subscribe(_ =>
                {
                    for (int i = 0; i < Blocks.Count; i++)
                    {
                        if (block == Blocks[i])
                        {
                            Blocks[i] = null;
                        }
                    }

                    if (Blocks.Count == _blockInLevel)
                    {
                        foreach (var block in Blocks)
                        {
                            if (block != null)
                            {
                                Debug.Log(block);
                                return;
                            }
                        }

                        _downBlockDestroyer.gameObject.SetActive(true);
                        Blocks.Clear();
                        _blockInLevel = 0;
                        _disposable.Clear();
                    }
                }).AddTo(_disposable);
            }
        }
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}
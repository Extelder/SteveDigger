using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerWalkAudio : MonoBehaviour
{
    [FormerlySerializedAs("_audioSource")] [SerializeField]
    private AudioSource _grassAudioSource;

    [FormerlySerializedAs("_audioSource")] [SerializeField]
    private AudioSource _stoneAudioSource;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnEnable()
    {
        gameObject.OnTriggerEnterAsObservable().Subscribe(_ =>
        {
            if (_.TryGetComponent<Block>(out Block Block))
            {
                _grassAudioSource.enabled = false;
                _stoneAudioSource.enabled = true;
            }
            else
            {
                _grassAudioSource.enabled = true;
                _stoneAudioSource.enabled = false;
            }
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}
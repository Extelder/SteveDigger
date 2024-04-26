using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour, IBlock
{
    [SerializeField] private UnityEvent BlockDestroyed;

    private AudioSource _source;

    private void Awake()
    {
        _source = transform.parent.gameObject.GetComponent<AudioSource>();
    }

    public void DestroyBlock()
    {
        _source.Play();
        BlockDestroyed?.Invoke();
        PlayerWallet.Instance.AddMoney(1);
        Destroy(gameObject);
    }
}
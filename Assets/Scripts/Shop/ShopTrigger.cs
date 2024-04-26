using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private AudioSource _music;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement movement))
        {
            _shop.Open();
            _music.Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement movement))
        {
            _shop.Close();
            _music.Play();
        }
    }
}
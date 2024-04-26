using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adv : MonoBehaviour
{
    private YandexSDK _yandexSdk;

    private void Awake()
    {
        _yandexSdk = GetComponent<YandexSDK>();
    }

    public void Aderstiment()
    {
        _yandexSdk.ShowInterstitial();
    }
}
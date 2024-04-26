using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UpgradeSpeed : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private SpeedItem[] _speedItems;
    [SerializeField] private SpeedItem _currentSpeedItem;
    [SerializeField] private SpeedItem _currentToBuyItem;

    private bool _cantBuy = false;

    private void Awake()
    {
        foreach (var speedItem in _speedItems)
        {
            if (speedItem.Id == PlayerPrefs.GetInt("SpeedItemID", _currentSpeedItem.Id))
            {
                _currentSpeedItem = speedItem;
                _movement.SetSpeed(_currentSpeedItem.Speed);
            }
        }

        foreach (var speedItem in _speedItems)
        {
            if (speedItem.Id == _currentSpeedItem.Id + 1)
            {
                _textMeshProUGUI.text = speedItem.Cost.ToString();
                _image.sprite = speedItem.Sprite;
                _currentToBuyItem = speedItem;
                return;
            }
        }


        _textMeshProUGUI.text = _currentSpeedItem.Cost.ToString();
        _image.sprite = _currentSpeedItem.Sprite;
        _currentToBuyItem = _currentSpeedItem;

        _cantBuy = true;
    }

    public void Buy()
    {
        if (_cantBuy)
            return;
        if (!_wallet.HaveMoney(_currentToBuyItem.Cost))
            return;

        if (_currentSpeedItem.Id + 1 < _speedItems.Length)
        {
            _wallet.TrySpendMoney(_currentToBuyItem.Cost);

            _currentSpeedItem = _currentToBuyItem;
            _movement.SetSpeed(_currentSpeedItem.Speed);

            PlayerPrefs.SetInt("SpeedItemID", _currentSpeedItem.Id);

            foreach (var speedItem in _speedItems)
            {
                if (speedItem.Id == _currentSpeedItem.Id + 1)
                {
                    _textMeshProUGUI.text = speedItem.Cost.ToString();
                    _image.sprite = speedItem.Sprite;
                    _currentToBuyItem = speedItem;
                    PlayerPrefs.SetInt("SpeedItemID", _currentSpeedItem.Id);
                    return;
                }
            }
        }
        else
        {
            _cantBuy = true;
        }
    }
}
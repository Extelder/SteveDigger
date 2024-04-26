using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UpgradeDestroyRate : MonoBehaviour
{
    [SerializeField] private Item[] _items;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private BlockDestroyer _destroyer;
    [SerializeField] private DestroyBlockItem[] _destroyBlockItems;
    [SerializeField] private DestroyBlockItem _currentBoughtItem;
    [SerializeField] private DestroyBlockItem _currentToBuyItem;

    [SerializeField] private Item _pickaxeItem;

    private bool _cantBuy = false;

    private void Awake()
    {
        foreach (var destroyBlockItem in _destroyBlockItems)
        {
            if (destroyBlockItem.Id == PlayerPrefs.GetInt("DestroyBlockItemID", _currentBoughtItem.Id))
            {
                _currentBoughtItem = destroyBlockItem;
                _destroyer.DestroyRate = _currentBoughtItem.Rate;
            }
        }

        foreach (var destroyBlockItem in _destroyBlockItems)
        {
            if (destroyBlockItem.Id == _currentBoughtItem.Id + 1)
            {
                _textMeshProUGUI.text = destroyBlockItem.Cost.ToString();
                _image.sprite = destroyBlockItem.Sprite;
                _currentToBuyItem = destroyBlockItem;
                foreach (var item in _items)
                {
                    if (item.BuyableItem.Id == _currentBoughtItem.Id)
                    {
                        _pickaxeItem.gameObject.SetActive(false);
                        _pickaxeItem = item;
                        _pickaxeItem.gameObject.SetActive(true);
                        break;
                    }
                }

                return;
            }
        }


        _textMeshProUGUI.text = _currentBoughtItem.Cost.ToString();
        _image.sprite = _currentBoughtItem.Sprite;
        _currentToBuyItem = _currentBoughtItem;

        foreach (var item in _items)
        {
            if (item.BuyableItem.Id == _currentBoughtItem.Id)
            {
                _pickaxeItem.gameObject.SetActive(false);
                _pickaxeItem = item;
                _pickaxeItem.gameObject.SetActive(true);
                break;
            }
        }

        _cantBuy = true;
    }

    public void Buy()
    {
        if (_cantBuy)
            return;
        if (!_wallet.HaveMoney(_currentToBuyItem.Cost))
            return;

        if (_currentBoughtItem.Id + 1 < _destroyBlockItems.Length)
        {
            _wallet.TrySpendMoney(_currentToBuyItem.Cost);
            _destroyer.DestroyRate = _currentToBuyItem.Rate;

            _pickaxeItem.gameObject.SetActive(false);
            foreach (var item in _items)
            {
                if (item.BuyableItem.Id == _currentToBuyItem.Id)
                {
                    _pickaxeItem = item;
                    _pickaxeItem.gameObject.SetActive(true);
                    break;
                }
            }

            _currentBoughtItem = _currentToBuyItem;
            PlayerPrefs.SetInt("DestroyBlockItemID", _currentBoughtItem.Id);

            foreach (var destroyBlockItem in _destroyBlockItems)
            {
                if (destroyBlockItem.Id == _currentBoughtItem.Id + 1)
                {
                    _textMeshProUGUI.text = destroyBlockItem.Cost.ToString();
                    _image.sprite = destroyBlockItem.Sprite;
                    _currentToBuyItem = destroyBlockItem;
                    PlayerPrefs.SetInt("DestroyBlockItemID", _currentBoughtItem.Id);
                    return;
                }
            }
        }
        else
        {
            PlayerPrefs.SetInt("CantBuy", 1);
            _cantBuy = true;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int _maxMoney = Int32.MaxValue;

    private int _money;

    public event Action<int> MoneyValueChanged;

    public static PlayerWallet Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    private void Start()
    {
        _money = PlayerPrefs.GetInt("Money", _money);
        MoneyValueChanged?.Invoke(_money);
    }

    public void AddMoney(int value)
    {
        if (_money + value < _maxMoney)
        {
            _money += value;
            MoneyValueChanged?.Invoke(_money);
            PlayerPrefs.SetInt("Money", _money);
        }
    }

    public void TrySpendMoney(int value)
    {
        if (_money - value >= 0)
        {
            _money -= value;
            MoneyValueChanged?.Invoke(_money);
            PlayerPrefs.SetInt("Money", _money);
        }
    }

    public bool HaveMoney(int value)
    {
        return _money >= value;
    }
}
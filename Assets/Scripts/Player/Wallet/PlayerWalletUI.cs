using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWalletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private PlayerWallet _wallet;

    private void OnEnable()
    {
        _wallet.MoneyValueChanged += OnMoneyValueChanged;
    }

    private void OnDisable()
    {
        _wallet.MoneyValueChanged -= OnMoneyValueChanged;
    }

    private void OnMoneyValueChanged(int value)
    {
        _textMeshProUGUI.text = value.ToString();
    }
}
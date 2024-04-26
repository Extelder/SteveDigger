using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    
    public void Open()
    {
        _shop.SetActive(true);
    }

    public void Close()
    {
        _shop.SetActive(false);
    }
}

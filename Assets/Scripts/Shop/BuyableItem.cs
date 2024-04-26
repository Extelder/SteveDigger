using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Shop", fileName = "Shop/BuyableItem")]
public class BuyableItem : ScriptableObject
{
    public int Id;
    public Sprite Sprite;
    public int Cost;
}
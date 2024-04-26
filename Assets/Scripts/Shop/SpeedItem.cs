using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpeedItem", fileName = "SpeedItem")]
public class SpeedItem : ScriptableObject
{
    public int Id;
    public int Cost;
    public Sprite Sprite;
    public float Speed;
}
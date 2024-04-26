using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DestroyBlockItem", fileName = "DestroyBlockItem")]
public class DestroyBlockItem : ScriptableObject
{
    public float Rate;
    public int Id;
    public Sprite Sprite;
    public int Cost;
}
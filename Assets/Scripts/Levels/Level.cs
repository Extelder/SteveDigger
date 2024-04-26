using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Level : MonoBehaviour
{
    [field: SerializeField] public Block[] BlocksOnLevel { get; private set; }
    public int Id { get; private set; }

    public void DestroyAllBlocks()
    {
        for (int i = 0; i < BlocksOnLevel.Length; i++)
        {
            Destroy(BlocksOnLevel[i].transform.parent.gameObject);
        }
    }
}
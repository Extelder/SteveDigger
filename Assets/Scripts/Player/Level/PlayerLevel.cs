using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private Level[] _allLevels;

    private Level _currentLevel;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            foreach (Level level in _allLevels)
            {
                if (level.Id == PlayerPrefs.GetInt("Level"))
                {
                    for (int i = 0; i < level.Id; i++)
                    {
                        _allLevels[i].DestroyAllBlocks();
                    }

                    _currentLevel = level;
                    return;
                }
            }
        }
    }
}
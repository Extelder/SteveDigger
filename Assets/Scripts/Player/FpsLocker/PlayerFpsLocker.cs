using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFpsLocker : MonoBehaviour
{
    [SerializeField] private int _targetFPS = 60;

    private void Start()
    {
        Application.targetFrameRate = _targetFPS;
    }
}
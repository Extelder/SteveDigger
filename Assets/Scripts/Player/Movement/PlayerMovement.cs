using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private AudioSource _walkAuidoSource;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] public float Gravity = -9.8f;

    private CharacterController _characterController;

    public Vector3 Direction { get; private set; }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        YandexSDK.instance.TimerStop += OnTimerStopped;
        YandexSDK.instance.TimerStart += OnTimerStarted;
    }

    private void OnDisable()
    {
        YandexSDK.instance.TimerStop -= OnTimerStopped;
        YandexSDK.instance.TimerStart -= OnTimerStarted;
    }

    private void OnTimerStopped()
    {
        _joystick.enabled = true;
        _characterController.enabled = true;
    }

    private void OnTimerStarted()
    {
        _joystick.enabled = false;
        _characterController.enabled = false;
    }

    private void FixedUpdate()
    {
        Direction = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);

        _characterController.Move(
            new Vector3(Direction.x * _moveSpeed, Gravity, Direction.z * _moveSpeed) * Time.deltaTime);
        if (Direction.sqrMagnitude > 0.1f)
        {
            transform.rotation =
                Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction), _rotationSpeed);
            if (_characterController.isGrounded)
            {
                _walkAuidoSource.gameObject.SetActive(true);
                return;
            }
        }

        _walkAuidoSource.gameObject.SetActive(false);
    }

    public void SetSpeed(float value)
    {
        _moveSpeed = value;
    }
}
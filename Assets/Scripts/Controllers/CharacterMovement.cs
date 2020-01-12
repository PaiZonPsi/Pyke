using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private IMovementProvider _movementProvider;
    private IJumpProvider _jumpProvider;
    private IGravityProvider _gravityProvider;
    private InputProvider _inputProvider;

    private Vector3 _moveDirection = Vector3.zero;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _gravityProvider = GetComponent<IGravityProvider>();
        _movementProvider = GetComponent<IMovementProvider>();
        _jumpProvider = GetComponent<IJumpProvider>();
        _inputProvider = GetComponent<InputProvider>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (_characterController.isGrounded)
        {
            _movementProvider.Movement(ref _moveDirection, _inputProvider.Inputs);
            _jumpProvider.Jump(ref _moveDirection);
        }
        _gravityProvider.AddGravity(ref _moveDirection);
    }

    private void FixedUpdate()
    { 
        SetMove(ref _moveDirection);
    }
    private void SetMove(ref Vector3 moveDirection)
    {
        _characterController.Move(moveDirection * Time.deltaTime);
    }
}
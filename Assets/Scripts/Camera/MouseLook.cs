using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField][Range(0f,200f)] private float mouseSensitivity = 100f;
    private Transform _playerBody;
    private float _xRotation = 0f;
    [SerializeField][Range(-90,90)] private float minDamp = 0f;
    [SerializeField][Range(-90,90)] private float maxDamp = 0f;
    private void Awake()
    {
        _playerBody = transform.parent.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, minDamp, maxDamp);
        transform.localRotation = Quaternion.Euler(_xRotation,0f,0f);
        _playerBody.Rotate(Vector3.up,mouseX);
    }
}

using System;
using UnityEngine;

public class PlayerInputProvider : InputProvider
{
    private void Update()
    {
        Inputs = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            Shoot = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Shoot = false;
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InputProvider: MonoBehaviour
{
    public Vector3 Inputs { get; protected set; } = Vector3.zero;
    public bool Shoot { get; protected set; } = false;
}
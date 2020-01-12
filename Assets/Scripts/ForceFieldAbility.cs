using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ForceFieldAbility : MonoBehaviour
{
    public GameObject Shape { get; set; } = null;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }
    }

    private void Use()
    {
        Instantiate(Shape, transform.position, Quaternion.identity);
        enabled = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireballAbility : MonoBehaviour
{
    public GameObject FireBall { get; set; } = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }
    }

    private void Use()
    {
        Instantiate(FireBall, transform.position, transform.rotation);
        enabled = false;
    }
}

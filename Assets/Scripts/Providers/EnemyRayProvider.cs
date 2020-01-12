using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayProvider : MonoBehaviour, IRayProvider
{
    private Transform _myTrasnform = null;

    private void Awake()
    {
        _myTrasnform = GetComponent<Transform>();
    }

    public Ray CreateRay()
    {
        Vector3 rayOrigin = _myTrasnform.position;
        Ray ray = new Ray(rayOrigin, _myTrasnform.forward);
        return ray;
    }

    public RaycastHit CheckRay(Ray ray)
    {
        Physics.Raycast(ray, out RaycastHit hit);
        return hit;
    }
}

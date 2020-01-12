using System;
using UnityEngine;

internal class CameraRayProvider : MonoBehaviour, IRayProvider
{
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    public Ray CreateRay()
    {
        Vector3 rayOrigin = _camera.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

        Ray ray = new Ray(rayOrigin, _camera.transform.forward);
        return ray;
    }

    public RaycastHit CheckRay(Ray ray)
    {
        Physics.Raycast(ray, out RaycastHit hitInfo);
        return hitInfo;
    }
}
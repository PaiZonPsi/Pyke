using UnityEngine;

internal interface IRayProvider
{
    Ray CreateRay();
    RaycastHit CheckRay(Ray ray);
}
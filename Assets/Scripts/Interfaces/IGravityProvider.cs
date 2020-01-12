using UnityEngine;

internal interface IGravityProvider
{
    void AddGravity(ref Vector3 _gravity);
}
using UnityEngine;

internal interface IMovementProvider
{
    void Movement(ref Vector3 move, Vector3 direction);
}
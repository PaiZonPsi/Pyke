using UnityEngine;

internal interface IJumpProvider
{
    void Jump(ref Vector3 moveDirection);
}
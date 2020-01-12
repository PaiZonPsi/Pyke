using UnityEngine;

internal class GravityProvider : MonoBehaviour, IGravityProvider
{
    public float gravity = 20.0f;

    public void AddGravity(ref Vector3 _gravity)
    {
        _gravity.y -= gravity * Time.deltaTime;
    }
}
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovementProvider : MonoBehaviour, IMovementProvider
{
    [SerializeField][Range(3.5f, 12.0f)] private float _speed = 6.0f;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }


    public void Movement(ref Vector3 move, Vector3 direction)
    {
        move = transform.right * direction.x + transform.forward * direction.z;
        move *= _speed;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
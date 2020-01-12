using UnityEngine;

internal class JumpProvider : MonoBehaviour, IJumpProvider
{
    [SerializeField] private float jumpSpeed = 8.0f;

    public float JumpSpeed
    {
        get => jumpSpeed;
        set => jumpSpeed = value;
    }

    public void Jump(ref Vector3 moveDirection)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            moveDirection.y = jumpSpeed;
        }
    }

    public void SetJump(float jump)
    {
        jumpSpeed = jump;
    }
}
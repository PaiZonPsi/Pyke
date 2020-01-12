using System;
using UnityEngine;

internal class PlayerHealthProvider : MonoBehaviour, IHealthProvider
{
    [SerializeField] private int _health = 100;
    private MeshRenderer _mesh;
    private Color _originalColor;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
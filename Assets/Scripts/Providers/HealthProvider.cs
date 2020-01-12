using System;
using System.Collections;
using UnityEngine;

internal class HealthProvider : MonoBehaviour, IHealthProvider
{
    [SerializeField] private int _health = 100;
    [SerializeField] private float _flashTime = 0.1f;
    [SerializeField] private Color _damageColor;
    private MeshRenderer _mesh;
    private Color _originalColor;
    

    private void Awake()
    {
        _mesh = gameObject.GetComponent<MeshRenderer>();
        _originalColor = _mesh.material.GetColor("_BaseColor");
    }

    public void TakeDamage(int damage)
    {
        _mesh.material.SetColor("_BaseColor",_damageColor);
        StartCoroutine(BackToOriginalColor());
        _health -= damage;
        if (_health <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FireballBehaviour>())
        {
            TakeDamage(other.GetComponent<FireballBehaviour>().Damage);
        }
    }

    private IEnumerator BackToOriginalColor()
    {
        yield return new WaitForSeconds(_flashTime);
        _mesh.material.SetColor("_BaseColor",_originalColor);
    }
}
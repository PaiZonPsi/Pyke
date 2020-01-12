using System;
using UnityEngine;

public class FireballBehaviour : ExpandingObjects
{
    [SerializeField] private float _speed = 4.0f;
    [SerializeField] private int _damage = 60;
    public int Damage => _damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startScale = GetComponent<Transform>().localScale;
    }

    private void Start()
    {
        rb.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }

    private void Update()
    {
        ScaleCheck();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyFollow>() && !isHit)
        {
            StartCoroutine(Explode());
            isHit = true;
        }
    }

    protected override void ScaleCheck()
    {
        base.ScaleCheck();
        if (transform.localScale.magnitude <= _maxSize.magnitude && isHit)
        {
            transform.localScale = ScaleObject(transform.localScale, _expandSpeed);
        }
    }
}
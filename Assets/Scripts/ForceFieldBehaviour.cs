using System.Collections;
using UnityEngine;

public class ForceFieldBehaviour : ExpandingObjects
{

    [SerializeField] private float _stunTime = 1.0f;

    public float StunTime => _stunTime;

    private void OnEnable()
    {
        StartCoroutine(Explode());
    }
    private void Update()
    {
        ScaleCheck();
    }

    protected override void ScaleCheck()
    {
        base.ScaleCheck();
        if (transform.localScale.magnitude <= _maxSize.magnitude)
        {
            transform.localScale = ScaleObject(transform.localScale, _expandSpeed);
        }
    }
}
using System.Collections;
using UnityEngine;

public abstract class ExpandingObjects : MonoBehaviour
{
    [SerializeField] protected Vector3 _maxSize = Vector3.zero;
    [SerializeField] protected float _expandSpeed = 2.5f;
    protected Rigidbody rb = null;
    protected Vector3 startScale = Vector3.zero;
    protected bool isHit = false;
    private bool _isMax = false;
    
    
    protected virtual void ScaleCheck()
    {
        if (transform.localScale.magnitude >= _maxSize.magnitude)
        {
            _isMax = true;
        }
    }

    protected Vector3 ScaleObject(Vector3 vector, float speed = 1.0f)
    {
        float deltaSpeed = (Time.deltaTime * speed);
        vector = new Vector3(vector.x + deltaSpeed, vector.y + deltaSpeed, vector.z + deltaSpeed);
        return vector;
    }
    
    protected IEnumerator Explode()
    {
        if (rb != null)
            rb.velocity = Vector3.zero;
        yield return new WaitUntil(() => _isMax == true);
        transform.localScale = startScale;
        Destroy(gameObject);
        isHit = false;
        _isMax = false;
    }
}
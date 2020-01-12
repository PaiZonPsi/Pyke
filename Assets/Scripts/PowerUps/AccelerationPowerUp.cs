using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationPowerUp : MonoBehaviour
{
    private bool _isInscreased = false;
    [SerializeField] private float _duration = 5.0f;
    [SerializeField] [Range(1.0f, 4.0f)]private float _factor = 1.5f;
    private float _powerUpedSpeed = 0.0f;
    private PlayerMovementProvider _player = null;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovementProvider>() && !_isInscreased)
        {
            _player = other.GetComponent<PlayerMovementProvider>();
            _powerUpedSpeed = other.GetComponent<PlayerMovementProvider>().Speed;
            _powerUpedSpeed *= _factor;
            other.GetComponent<PlayerMovementProvider>().SetSpeed(_powerUpedSpeed);
            _isInscreased = true;
            StartCoroutine(PowerUpDuration());
            _powerUpedSpeed /= _factor;
        }
    }

    private IEnumerator PowerUpDuration()
    {
        yield return new WaitForSeconds(_duration);
        _player.SetSpeed(_powerUpedSpeed);
        _isInscreased = false;
    }
}

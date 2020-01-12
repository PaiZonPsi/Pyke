using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpPowerUp : MonoBehaviour
{
    private bool _isInscreased = false;
    [SerializeField] private float _duration = 5.0f;
    [SerializeField] [Range(1.0f, 4.0f)]private float _factor = 1.5f;
    private float _powerUpedJump = 0.0f;
    private JumpProvider _player = null;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<JumpProvider>() && !_isInscreased)
        {
            _player = other.GetComponent<JumpProvider>();
            _powerUpedJump = other.GetComponent<JumpProvider>().JumpSpeed;
            _powerUpedJump *= _factor;
            other.GetComponent<JumpProvider>().SetJump(_powerUpedJump);
            _isInscreased = true;
            StartCoroutine(PowerUpDuration());
            _powerUpedJump /= _factor;
        }
    }

    private IEnumerator PowerUpDuration()
    {
        yield return new WaitForSeconds(_duration);
        _player.SetJump(_powerUpedJump);
        _isInscreased = false;
    }
}

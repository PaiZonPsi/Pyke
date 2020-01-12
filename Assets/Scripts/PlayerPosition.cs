using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private Transform _myTransform;
    public delegate void PlayerTargetPosition(Transform x);
    public static event PlayerTargetPosition OnPlayerPosition;
    private void OnEnable() { EnemyFollow.OnEnemySpawn += this.TellPosition; }
    private void OnDisable() { EnemyFollow.OnEnemySpawn -= this.TellPosition; }

    private void TellPosition()
    {
        _myTransform = GetComponent<Transform>();
        OnPlayerPosition?.Invoke(_myTransform);
    }
}

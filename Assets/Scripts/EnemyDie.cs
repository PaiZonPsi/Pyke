using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public delegate void DeathOfEnemy();
    public static event DeathOfEnemy OnEnemyDeath;

    private void OnDestroy()
    {
        OnEnemyDeath?.Invoke();
    }
}

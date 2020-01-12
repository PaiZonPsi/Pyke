using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    #region Variables
    private enum SpawnState{Waiting,Counting}
    [SerializeField] private Wave[] _waves = null;
    [SerializeField] private Transform[] _spawnPoints = null; 
    private int _nextWave = 0;
    [SerializeField] private float _breakTime = 3.0f;
    private float _waveCountdown;
    private SpawnState _state = SpawnState.Counting;
    private int _currentEnemyCount;
    #endregion
    
    private void OnEnable()
    {
        EnemyDie.OnEnemyDeath += this.EnemyDieCount;
    }
    private void OnDisable()
    {
        EnemyDie.OnEnemyDeath -= this.EnemyDieCount;
    }
    
    private void Start()
    {
        _waveCountdown = _breakTime;
        _currentEnemyCount = _waves[_nextWave].count;
    }

    private void Update()
    {
        if (_state == SpawnState.Waiting)
        {
            if (_currentEnemyCount <= 0)
            {
                if (_nextWave == _waves.Length - 1) 
                    _nextWave = 0;
                else
                    _nextWave++;
                
                _currentEnemyCount = _waves[_nextWave].count;
                _waveCountdown = _breakTime;
                _state = SpawnState.Counting;
            }
        } else if (_state == SpawnState.Counting)
        {
            if (_waveCountdown <= 0)
                SpawnWave(_waves[_nextWave]); 
            else 
                _waveCountdown -= Time.deltaTime;
        }
    }
    private void SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemies[Random.Range(0,wave.enemies.Length)]);
        }
        _state = SpawnState.Waiting;
    }
    private void SpawnEnemy(GameObject enemy)
    {
        Transform sp = _spawnPoints[Random.Range(0,_spawnPoints.Length)];
        Instantiate(enemy, sp.position, sp.rotation);
    }

    private void EnemyDieCount()
    {
        _currentEnemyCount--;
    }
}
[System.Serializable]
public class Wave
{
    public string name;
    public GameObject[] enemies;
    public int count;
}
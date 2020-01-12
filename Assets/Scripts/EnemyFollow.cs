using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyFollow : MonoBehaviour
{
    private Transform _target = null;
    private Transform _myTransform = null;
    private NavMeshAgent _agent = null;
    private EnemyWeaponProvider _weaponProvider = null;
    private Weapon _weapon = null;
    private float _speed = 0.0f;
    private bool _canShoot = true;

    public delegate void EnemySpawn();
    public static event EnemySpawn OnEnemySpawn;
    
    private void Awake()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _myTransform = GetComponent<Transform>();
        _weaponProvider = GetComponent<EnemyWeaponProvider>();
        _weapon = _weaponProvider.Weapon;
        _speed = _agent.speed;
    }

    #region Delegate
    private void OnEnable()
    {
        PlayerPosition.OnPlayerPosition += this.PlayerTransform;
    }

    private void Start()
    {
        OnEnemySpawn?.Invoke();
    }

    private void PlayerTransform(Transform x)
    {
        _target = x;
    }
    #endregion
    
    private void Update()
    {
        if (_target == null && _agent == null) return;
        Vector3 targetPosition = _target.position;
        _agent.SetDestination(targetPosition);
        Vector3 myPosition = _myTransform.position;
        float distance = Vector3.Distance(myPosition, targetPosition);
        float dotProduct = Vector3.Dot(transform.forward, (targetPosition - myPosition));
        if (distance < _weapon.range)
        {
            FaceTarget();
            if (dotProduct > 0.6f && _canShoot)
            {
                _weaponProvider.Fire();
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 lookPos = _agent.destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);  
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 12)
        {
            float stunTime = other.gameObject.GetComponent<ForceFieldBehaviour>().StunTime;
            StartCoroutine(StunMe(stunTime));

        }
    }

    private IEnumerator StunMe(float stunTime = 1.0f)
    {
        _agent.speed = 0.0f;
        _canShoot = false;
        yield return new WaitForSeconds(stunTime);
        _agent.speed = _speed;
        _canShoot = true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon Data")]
public class Weapon : ScriptableObject
{
    public int damage = 20;
    public float fireRate = 1.0f;
    public float range = 10.0f;
    public int maxAmmo = 30;

    [SerializeField] private float _reloadTime = 1.5f;
    [SerializeField] private int _maxAmmoInClip = 7;
    private int _currentAmmoInClip = 30;
    private bool _reloading = false;
    
    public int CurrentAmmo { get; set; }
    public float CurrentFireRate { get; set; }

    public int CurrentAmmoInClip
    {
        get => _currentAmmoInClip;
        set => _currentAmmoInClip = value;
    }

    public int MaxAmmoInClip
    {
        get => _maxAmmoInClip;
        set => _maxAmmoInClip = value;
    }

    private void Awake()
    {
        CurrentAmmo = maxAmmo;
        CurrentAmmoInClip = MaxAmmoInClip;
    }

    public bool CanShoot()
    {
        return CurrentFireRate <= 0 && _currentAmmoInClip > 0 && !_reloading;
    }

    public void ReloadAmmo()
    {
        if (_currentAmmoInClip < MaxAmmoInClip)
        {
            if (CurrentAmmo >= MaxAmmoInClip)
            {
                int ammo = MaxAmmoInClip - _currentAmmoInClip;
                _currentAmmoInClip = MaxAmmoInClip;
                CurrentAmmo -= ammo;
            } else if (CurrentAmmo < MaxAmmoInClip)
            {
                _currentAmmoInClip = CurrentAmmo;
                CurrentAmmo = 0;
            }
        }
    }

    public IEnumerator Reload()
    {
        _reloading = true;
        yield return new WaitForSeconds(_reloadTime);
        ReloadAmmo();
        _reloading = false;
    }
}

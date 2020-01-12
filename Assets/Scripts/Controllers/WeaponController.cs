using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    private IWeaponProvider _weaponProvider = null;

    private void Awake()
    {
        _weaponProvider = GetComponent<IWeaponProvider>();
    }

    private void Update()
    {
        _weaponProvider.Fire();
        _weaponProvider.Reload();
    }
}
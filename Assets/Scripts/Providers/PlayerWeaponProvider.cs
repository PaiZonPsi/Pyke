using UnityEngine;
using UnityEngine.UI;
using TMPro;

internal class PlayerWeaponProvider : MonoBehaviour, IWeaponProvider
{
    [SerializeField] private Weapon _weapon = null;
    [SerializeField] private TextMeshProUGUI _ammoUi = null;
    private ParticleSystem _bulletFlashParticleSystem;
    private InputProvider _inputProvider = null;
    private IRayProvider _rayProvider = null;
    private IHealthProvider _healthProvider = null;
    

    private void Awake()
    {
        _rayProvider = GetComponent<IRayProvider>();
        _inputProvider = GetComponent<InputProvider>();
        _bulletFlashParticleSystem = GetComponentInChildren<ParticleSystem>();
        _weapon.CurrentAmmoInClip = _weapon.MaxAmmoInClip;
        _weapon.CurrentAmmo = _weapon.maxAmmo;
        AmmoUI();
    }

    public void Fire()
    {
        AmmoUI();
        if (_weapon.CanShoot() && _inputProvider.Shoot)
        {
            _weapon.CurrentAmmoInClip--;
            _weapon.CurrentFireRate = _weapon.fireRate;
            _bulletFlashParticleSystem.Play();
            var hit = _rayProvider.CheckRay(_rayProvider.CreateRay());
            if (hit.collider != null)
            {
                _healthProvider = hit.collider.GetComponent<IHealthProvider>();
                _healthProvider?.TakeDamage(_weapon.damage);
            }
        }else if (!_weapon.CanShoot())
            _weapon.CurrentFireRate -= Time.deltaTime;
    }

    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(_weapon.Reload());
        }
    }

    private void AmmoUI()
    {
        _ammoUi.text = $"{_weapon.CurrentAmmoInClip.ToString()} / {_weapon.CurrentAmmo.ToString()}";
    }
}
using UnityEngine;

internal class EnemyWeaponProvider : MonoBehaviour, IWeaponProvider
{
    [SerializeField] private Weapon _weapon = null;
    private IRayProvider _rayProvider = null;
    private IHealthProvider _healthProvider = null;
    public Weapon Weapon => _weapon;

    private void Awake()
    {
        _rayProvider = GetComponent<IRayProvider>();
        _weapon.CurrentAmmoInClip = _weapon.MaxAmmoInClip;
        _weapon.CurrentAmmo = _weapon.maxAmmo;
    }

    public void Fire()
    {
        if (_weapon.CanShoot())
        {
            _weapon.CurrentAmmoInClip--;
            var hit = _rayProvider.CheckRay(_rayProvider.CreateRay());
            if (hit.collider != null)
            {
                _healthProvider = hit.collider.GetComponent<IHealthProvider>();
                _healthProvider?.TakeDamage(_weapon.damage);
                _weapon.CurrentFireRate = _weapon.fireRate;
            }
        }else if (!_weapon.CanShoot())
            _weapon.CurrentFireRate -= Time.deltaTime;
        Reload();
    }

    public void Reload()
    {
        if (_weapon.CurrentAmmoInClip <= 0)
        {
            StartCoroutine(_weapon.Reload());
        }
    }
}
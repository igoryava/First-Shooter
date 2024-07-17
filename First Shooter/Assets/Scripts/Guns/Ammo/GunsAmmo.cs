using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GunsAmmo : MonoBehaviour
{
    [SerializeField] private int _maxAmmo;

    [SerializeField] private KeyCode _reloadKey;

    [SerializeField] private RaycastShoot _raycastShoot;

    public bool CanShoot;

    private int _currentAmmo;

    private void Start()
    {
        _currentAmmo = _maxAmmo;
    }

    private void Update()
    {
        if (_currentAmmo < _maxAmmo)
        {
            Reload();
        }

        if (_currentAmmo <= 0)
        {
            CanShoot = false;
        }
        else
        {
            CanShoot = true;
        }
    }

    private void AmmoChange()
    {
        _currentAmmo--;
    }

    private void OnEnable()
    {
        _raycastShoot.OnShooted += AmmoChange;
    }

    private void OnDisable()
    {
        _raycastShoot.OnShooted -= AmmoChange;
    }

    private void Reload()
    {
        if (Input.GetKeyDown(_reloadKey))
        {
            _currentAmmo = _maxAmmo;
        }
    }
}

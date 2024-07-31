using System;
using UnityEngine;

public class RaycastShootEffects : MonoBehaviour
{
    [SerializeField] private RaycastShoot _raycastShoot;

    private void OnEnable()
    {
        _raycastShoot.OnShooted += OnShootPerform;
    }

    private void OnDisable()
    {
        _raycastShoot.OnShooted -= OnShootPerform;
    }

     private void OnShootPerform()
    {
        CinemachineShake.Instance.ShakeCamera(1f, 0.3f);
    }
}

using UnityEngine;

public class RaycastShootMuzzleFlash : MonoBehaviour
{
    [SerializeField] private ParticleSystem _muzzleFlash;
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
        _muzzleFlash.Play();
    }
}

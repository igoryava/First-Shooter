using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RaycastShoot : MonoBehaviour
{
    [field: SerializeField] public float Damage;

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _distance = Mathf.Infinity;
    [SerializeField] private int _shootCount;

    [SerializeField] private bool _useSpead;
    [SerializeField] private float _spreadFactor;

    public event Action <RaycastHit> OnRaycastHit;
    public event Action OnShooted;

    public RaycastHit hitInfo;

    public void PerformAttack()
    {
        for (var i = 0; i < _shootCount; i++)
        {
            PerformRaycast();
        }
    }

    public virtual void Accept(IWeaponVisitor visitor)
    {
        visitor.Visit(this, hitInfo);
    }

    private void PerformRaycast()
    {
        var directon = _useSpead ? transform.forward + CalculateSpread() : transform.forward;
        var ray = new Ray(transform.position, directon);
        OnShooted?.Invoke();
        if (Physics.Raycast(ray, out hitInfo, _distance, _layerMask))
        {
            OnRaycastHit?.Invoke(hitInfo);
            var hitCollider = hitInfo.collider;

            if(hitCollider.TryGetComponent<IWeaponVisitor>(out IWeaponVisitor _iWeaponVisitor))
            {
                Accept(_iWeaponVisitor);
            }
        }
    }

    private Vector3 CalculateSpread()
    {
        return new Vector3
        {
            x = Random.Range(-_spreadFactor, _spreadFactor),
            y = Random.Range(-_spreadFactor, _spreadFactor),
            z = Random.Range(-_spreadFactor, _spreadFactor)
        };
    }

    private void OnDrawGizmosSelected()
    {
        var ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out var hitInfo, _distance, _layerMask))
        {
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        }
        else
        {
            var hitPosition = ray.origin + ray.direction * _distance;

            DrawRay(ray, hitPosition, _distance, Color.green);
        }
    }

    private static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        const float hitPointRadius = 0.1f;

        Debug.DrawRay(ray.origin, ray.direction * distance, color);

        Gizmos.color = color;   
        Gizmos.DrawSphere(hitPosition, hitPointRadius);
    }
}

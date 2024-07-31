using UnityEngine;

public class RaycastShootSpawnTrails : MonoBehaviour
{
    [SerializeField] private RaycastShoot _raycastShoot;
    [SerializeField] private TrailRenderer _bulletTrail;
    [SerializeField] private Transform _bulletSpawnPosition;


    private void OnEnable()
    {
        _raycastShoot.OnRaycastHit += CheckTrail;
    }
    private void OnDisable()
    {
        _raycastShoot.OnRaycastHit -= CheckTrail;
    }

    private void CheckTrail(RaycastHit hit)
    {
        TrailRenderer trail = Instantiate(_bulletTrail, _bulletSpawnPosition.position, Quaternion.identity);
        trail.GetComponent<TrailMove>().MoveTrail(hit.point);
    }
}

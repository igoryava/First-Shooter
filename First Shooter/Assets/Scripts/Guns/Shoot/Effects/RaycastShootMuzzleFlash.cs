using UnityEngine;

public class RaycastShootMuzzleFlash : MonoBehaviour
{
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private KeyCode _shootKey;

    private void Start()
    {
    }

    private void Update()
    {
        if(Input.GetKeyDown(_shootKey))
        {
            _muzzleFlash.Play();
        }
    }
}

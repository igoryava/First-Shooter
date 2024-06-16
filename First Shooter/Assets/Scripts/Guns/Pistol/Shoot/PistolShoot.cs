using UnityEngine;
public class PistolShoot : RaycastShoot
{
    [SerializeField] private KeyCode _shootKey;

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            PerformAttack();
        }
    }
}

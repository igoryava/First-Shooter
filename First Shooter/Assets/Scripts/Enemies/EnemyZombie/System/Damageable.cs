using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private HealthEnemyZombie _health;

    public void ApplyDamage(float value)
    {
        _health.TakeDamage(value);
    }
}

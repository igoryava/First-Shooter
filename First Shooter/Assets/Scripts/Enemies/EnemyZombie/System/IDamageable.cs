using UnityEngine;

public class IDamageable : MonoBehaviour
{
    [SerializeField] private HealthEnemyZombie _health;

    public void ApplyDamage(float value)
    {
        _health.TakeDamage(value);
    }
}

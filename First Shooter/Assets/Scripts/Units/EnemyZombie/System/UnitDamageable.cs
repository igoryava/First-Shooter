using UnityEngine;

public class UnitDamageable : MonoBehaviour
{
    [SerializeField] private HealthEnemyZombie _health;
    public void ApplyDamage(float value)
    {
        if(value < 0)
            return;
        Debug.Log(value);

        _health.TakeDamage(value);
    }
}

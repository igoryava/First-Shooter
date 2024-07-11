using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event Action<float> IsHealthChanged;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float value)
    {
        if(_currentHealth - value <= 0)
        {
            _currentHealth = 0;
            Death();
            return;
        }
        _currentHealth -= value;
    }

    public virtual void Death()
    {
        IsHealthChanged?.Invoke(_currentHealth);
        Debug.Log("fwd");
    }
}

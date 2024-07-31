using Unity.VisualScripting;
using UnityEngine;

public class UnitHitBox : MonoBehaviour, IWeaponVisitor
{
    [SerializeField] private Unit _unit;
    [SerializeField] private Collider _hitBox;
    [SerializeField] public UnitDecalPresets DecalPresets;
    [SerializeField] private UnitDamageable _damageable;

    public virtual void Visit(Pistol weapon, RaycastHit raycastHit)
    {
        DefaultRaycastVisit(weapon , DecalPresets.DefaultDecal ,raycastHit);
    }

    public virtual void Visit(RaycastShoot weapon, RaycastHit raycastHit)
    {
    }

    public void DefaultRaycastVisit(Pistol weapon, GameObject decal, RaycastHit raycastHit, int damageMultiplier = 1)
    {
        var damage = weapon.Damage * damageMultiplier;
        Debug.Log(damage);
        _damageable.ApplyDamage(damage);
        SpawnDecal(decal, raycastHit);
    }

    private void SpawnDecal(GameObject decal, RaycastHit hit)
    {
        
    }
}

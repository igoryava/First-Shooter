using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(Pistol weapon, RaycastHit raycastHit);
    public void Visit(RaycastShoot weapon, RaycastHit raycastHit);
}

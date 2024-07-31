using UnityEngine;

public class UnitHeadHitBox : UnitHitBox
{
    public override void Visit(Pistol weapon, RaycastHit raycastHit)
    {
        DefaultRaycastVisit(weapon, DecalPresets.HeadShotDecal, raycastHit, 2);
    }


    public override void Visit(RaycastShoot weapon, RaycastHit raycastHit)
    {
    }
}

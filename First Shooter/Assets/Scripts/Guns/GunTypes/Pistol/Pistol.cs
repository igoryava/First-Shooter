using System.Collections;
using UnityEngine;
public class Pistol : RaycastShoot
{
    [SerializeField] private KeyCode _shootKey;
    [SerializeField] private GunsAmmo _gunAmmo;

    private void Start()
    {
        StartCoroutine(ShootingCooldown());
    }

    private IEnumerator ShootingCooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.002f);
            if (Input.GetKeyDown(_shootKey) && _gunAmmo.CanShoot == true)
            {
                PerformAttack();
                yield return new WaitForSeconds(0.6f);
            }
        }
    }

    public override void Accept(IWeaponVisitor visitor)
    {
        visitor.Visit(this, hitInfo);
    }
}

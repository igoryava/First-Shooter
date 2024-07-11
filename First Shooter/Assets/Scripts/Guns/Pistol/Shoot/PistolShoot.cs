using System;
using System.Collections;
using UnityEngine;
public class PistolShoot : RaycastShoot
{
    [SerializeField] private KeyCode _shootKey;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.002f);
            if (Input.GetKeyDown(_shootKey))
            {
                PerformAttack();
                yield return new WaitForSeconds(0.6f);
            }
        }
    }
}

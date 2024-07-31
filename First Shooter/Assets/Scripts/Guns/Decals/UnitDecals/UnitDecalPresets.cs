using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDecalPresets : ScriptableObject
{
    [field: SerializeField]  public GameObject DefaultDecal { get; private set; }
    [field: SerializeField]  public GameObject HeadShotDecal { get; private set; }
}

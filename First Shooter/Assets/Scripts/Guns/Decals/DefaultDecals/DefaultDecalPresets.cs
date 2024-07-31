using UnityEngine;

public class DefaultDecalPresets : ScriptableObject
{
    [field: SerializeField] public GameObject MetallDecal { get; private set; }
    [field: SerializeField] public GameObject WoodDecal { get; private set; }
    [field: SerializeField] public GameObject AsphaltDecal { get; private set; }
}

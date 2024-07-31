using UnityEngine;
using System.Collections.Generic;

public class DecalsPool : MonoBehaviour
{
    [field: SerializeField] public static DecalsPool Instance { get; private set; }
    [SerializeField] private int _amountToPool;
    [SerializeField] private GameObject _decal;

    private List<GameObject> _pooledObjects = new List<GameObject> ();

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < _amountToPool;  i++)
        {
            GameObject decal = Instantiate(_decal);
            decal.SetActive(false);
            _pooledObjects.Add(decal);
        }
    }

    public GameObject GetPooledDecal()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        return null;
    }
}

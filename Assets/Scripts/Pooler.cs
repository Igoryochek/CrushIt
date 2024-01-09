using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pooledObjects;

    public bool TryGetObject(out GameObject foundObject)
    {
        foundObject = _pooledObjects.FirstOrDefault(f => f.activeSelf == false);
        return foundObject != null;
    }
}

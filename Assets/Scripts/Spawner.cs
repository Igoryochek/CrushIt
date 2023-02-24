using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PLayerMover _player;
    [SerializeField] private List< HelperMover> _helpersPool;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        CreateHelper();
    }

    public void CreateHelper()
    {
        if (TryGetHelper(out HelperMover helper))
        {
            helper.gameObject.SetActive(true);
            _player.AddHelper(helper);
        }
    }

    private bool TryGetHelper(out HelperMover helper)
    {
        helper = _helpersPool.FirstOrDefault(h=>h.gameObject.activeSelf);
        return helper != null;
    }
}

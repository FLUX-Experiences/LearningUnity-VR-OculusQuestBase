using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagicSpawn : MonoBehaviour
{
    public GameObject FirePrefab;
    public Transform StartingPoint;
    public Transform SpawnerParent;

    void Start()
    {
        
    }

    public void SpawnFire()
    {
        Instantiate(FirePrefab, StartingPoint.position, StartingPoint.rotation, SpawnerParent);
    }
    public void SpawnFire(Transform _startingPoint)
    {
        if (_startingPoint == null) SpawnFire();
        else Instantiate(FirePrefab, _startingPoint.position, _startingPoint.rotation, SpawnerParent);
    }
}

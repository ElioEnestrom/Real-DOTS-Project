using Unity.Entities;
using UnityEngine;


public struct EnemySpawnerComponent : IComponentData
{
    public float EnemySpawnCooldown;
    public Vector3 EnemyLocation;
}
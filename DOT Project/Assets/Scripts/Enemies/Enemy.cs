using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Enemy : IComponentData
{
    public List<EnemyData> enemies;
}

public struct EnemySpawnerComponent : IComponentData
{
    public float enemySpawnCooldown;
}

public struct EnemyData
{
    public Entity prefab;
    public int speed;
}

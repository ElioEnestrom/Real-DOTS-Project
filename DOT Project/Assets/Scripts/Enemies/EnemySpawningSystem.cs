using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.VisualScripting;
using UnityEngine;

public partial class EnemySpawningSystem : SystemBase
{
    private EnemySpawnerComponent _enemySpawnerComponent;
    private Enemy _enemyDataComponent;
    private Entity _enemySpawnerEntity;
    protected override void OnUpdate()
    {
    }

    protected override void OnStartRunning()
    {
        if (!SystemAPI.TryGetSingletonEntity<EnemySpawnerComponent>(out _enemySpawnerEntity))
        {
            return;
        }

        _enemySpawnerComponent = EntityManager.GetComponentData<EnemySpawnerComponent>(_enemySpawnerEntity);
        _enemyDataComponent = EntityManager.GetComponentObject<Enemy>(_enemySpawnerEntity);

        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        List<EnemyData> availableEnemies = new List<EnemyData>();

        foreach (EnemyData enemyData in _enemyDataComponent.Enemies)
        {
            availableEnemies.Add(enemyData);
        }

        int index = 0;

        Entity newEnemy = EntityManager.Instantiate(availableEnemies[index].Prefab);
        EntityManager.SetComponentData(newEnemy, new LocalTransform
        {
            Position = float3.zero,
            Rotation = quaternion.identity,
            Scale = 1
        });
    }
}

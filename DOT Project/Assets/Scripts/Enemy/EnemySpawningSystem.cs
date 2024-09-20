using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public partial class EnemySpawningSystem : SystemBase
{
    private EnemySpawnerComponent _enemySpawnerComponent;
    private Enemy _enemyDataComponent;
    private Entity _enemySpawnerEntity;
    private const float SpawnOffset = 2.5f;
    private float _respawning, _newRespawningTime = 0f;

    protected override void OnUpdate()
    {
        if(_respawning >= _newRespawningTime)
        {
            SpawnEnemies();
            _newRespawningTime = _respawning + 5f;
        }
        Debug.Log(_respawning);
        Debug.Log(_newRespawningTime);

        _respawning = _respawning += UnityEngine.Time.deltaTime;
    }

    protected override void OnStartRunning()
    {
        Debug.Log("What");
        if (!SystemAPI.TryGetSingletonEntity<EnemySpawnerComponent>(out _enemySpawnerEntity))
        {
            return;
        }
        
        _enemySpawnerComponent = EntityManager.GetComponentData<EnemySpawnerComponent>(_enemySpawnerEntity);
        _enemyDataComponent = EntityManager.GetComponentObject<Enemy>(_enemySpawnerEntity);

        Debug.Log("Trying to spawn enemies");
    }

    private void SpawnEnemies()
    {
        List<EnemyData> availableEnemies = new List<EnemyData>();

        foreach (EnemyData enemyData in _enemyDataComponent.Enemies)
        {
            availableEnemies.Add(enemyData);
        }

        int index = 0;

        for (int i = 0; i < availableEnemies.Count; i++)
        {
            Entity newEnemy = EntityManager.Instantiate(availableEnemies[i].Prefab);
            Debug.Log("Spawned enemy");
            EntityManager.SetComponentData(newEnemy, new LocalTransform
            {
                Position = new Vector3(_enemySpawnerComponent.EnemyLocation.x + i * SpawnOffset, _enemySpawnerComponent.EnemyLocation.y, _enemySpawnerComponent.EnemyLocation.z) ,
                Rotation = quaternion.identity,
                Scale = 1
            });

            EntityManager.AddComponentData(newEnemy, new EnemyComponent() { }); 
        }
    }
}

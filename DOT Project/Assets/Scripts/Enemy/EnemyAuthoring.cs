using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class EnemyAuthoring : MonoBehaviour
{
    public float spawnCooldown = 1;
    public Transform enemyPosition;
    public List<EnemySO> enemiesSO;
    
    class EnemyAuthoringBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            Entity enemyEntity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(enemyEntity, new EnemySpawnerComponent()
            {
                EnemySpawnCooldown = authoring.spawnCooldown,
                EnemyLocation = authoring.enemyPosition.transform.position
            });
            
            List<EnemyData> enemyData = new List<EnemyData>();
            
            //AddComponent<EnemySpawning>(enemyEntity);

            foreach (EnemySO enemy in authoring.enemiesSO)
            {
                enemyData.Add(new EnemyData
                {
                    Speed = enemy.speed,
                    Prefab = GetEntity(enemy.prefab, TransformUsageFlags.None)
                });
            }
            
            AddComponentObject(enemyEntity, new Enemy{Enemies = enemyData});
        }
    }
}

public struct EnemyMovement : IComponentData
{
    public float2 Value;
}

//public struct EnemySpawning : IComponentData
//{
//    public Entity[] Value;
//}

using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class EnemyAuthoring : MonoBehaviour
{
    
    class EnemyAuthoringBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            Entity enemyEntity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent<EnemySpawning>(enemyEntity);
        }
    }
}

public struct EnemyMovement : IComponentData
{
    public float2 Value;
}

public struct EnemySpawning : IComponentData
{
    public Entity[] Value;
}

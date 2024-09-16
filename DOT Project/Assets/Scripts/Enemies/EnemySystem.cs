using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct EnemySystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        
    }
    
    void OnStartRunning(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.TempJob);
        
        foreach (var (enemySpawning, transform) in SystemAPI.Query<EnemySpawning, LocalTransform>())
        {
            Entity[] newProjectile = new Entity[20];
        }   
        
    }
        
}
